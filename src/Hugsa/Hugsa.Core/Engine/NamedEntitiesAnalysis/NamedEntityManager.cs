using System.Linq;
using Hugsa.Core.Engine;
using Hugsa.Core.Engine.CandidateTypes;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.CandidateTypes;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine {
    public class NamedEntityManager {
        private AbstractNamedEntityType[] namedEntityTypes = {
                new OrganisationNamedEntityType(),
                new PlaceNamedEntityType(), 
                new PersonNamedEntityType(), 
            };

        private readonly AbstractCandidateType[] candidateTypes = {
            new NumberCandidateType(),
            new SigleCandidateType(),
            new FirstUpperCandidateType(), 
        };

        public void AnalyzeWordAsCandidate(Word word) {
            word.CandidateTypes = this.candidateTypes.Where(candidateType => candidateType.IsCandidate(word));
        }

        public void AnalyzeTextForCandidates(Text text) {
            foreach (var sentence in text.Sentences) {
                foreach (var word in sentence.Words) {
                    this.AnalyzeWordAsCandidate(word);
                }
            }
        }

        public void AnalyzeTextForNamedEntities(Text text) {
            var context = new Context(text);

            while (!context.HasFinished()) {
                var report = this.AnalyzeWordAsNamedEntity(context.CurrentWord, context);

                context.GoToNextWord(report);
            }
        }

        public WordSemanticsAnalysisReport AnalyzeWordAsNamedEntity(Word word, Context context) {
            var bestReport = this.namedEntityTypes.Select(type => type.Analyze(word, context))
                .Where(report => report != null)
                .OrderByDescending(report => report.Semantics.Words.Count())
                .FirstOrDefault();

            if (bestReport == null) {
                bestReport = new WordSemanticsAnalysisReport {
                    Semantics = new UnknownWordSemantics(word),
                };
            }

            return bestReport;
        }

        public class Context {
            private readonly Text text;

            public Word CurrentWord {
                get {
                    return text.Sentences.ElementAt(this.sentenceId).Words.ElementAt(wordId);
                }
            }

            private int sentenceId;
            private int wordId;

            public Context(Text text) {
                this.text = text;
            }

            public void GoToNextWord(WordSemanticsAnalysisReport report) {
                this.ApplyReportToSentence(report);

                var currentSentence = text.Sentences.ElementAt(sentenceId);
                wordId += 1;

                if (wordId >= currentSentence.Words.Count()) {
                    // next sentence
                    sentenceId++;
                    wordId = 0;
                }
            }

            public Word GetPreviousWord() {
                var previousWordId = wordId - 1;
                var currentSentence = text.Sentences.ElementAt(this.sentenceId);

                if (previousWordId < 0 || previousWordId >= currentSentence.Words.Count()) {
                    return null;
                }

                return currentSentence.Words.ElementAt(previousWordId);
            }

            public Word GetNextWord() {
                var nextWordId = wordId + 1;
                var currentSentence = text.Sentences.ElementAt(this.sentenceId);

                if (nextWordId < 0 || nextWordId >= currentSentence.Words.Count()) {
                    return null;
                }

                return currentSentence.Words.ElementAt(nextWordId);
            }

            private void ApplyReportToSentence(WordSemanticsAnalysisReport report) {
                var currentSemantics = text.Sentences.ElementAt(this.sentenceId).Semantics;

                if (!report.Semantics.IsUnknown) {
                    currentSemantics.Add(report.Semantics);
                }
            }

            public bool HasFinished() {
                return this.sentenceId >= text.Sentences.Count();
            }
        }

        public class WordSemanticsAnalysisReport {
            public ISemantics Semantics { get; set; }
            public int LeftWords { get; set; }
            public int RightWords { get; set; }
        }
    }
}
