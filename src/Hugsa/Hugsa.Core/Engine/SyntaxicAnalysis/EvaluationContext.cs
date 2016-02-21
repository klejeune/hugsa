using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class EvaluationContext<TItem> {
        public IEnumerable<TItem> Words { get; private set; }
        private readonly List<EvaluationContext<TItem>> subEvaluationContexts = new List<EvaluationContext<TItem>>();
        public IEnumerable<EvaluationContext<TItem>> SubEvaluationContexts {
            get {
                return this.subEvaluationContexts;
            }
        }

        public EvaluationContext(IEnumerable<TItem> words) {
            this.Words = words.ToList();
        }

        public void SetSubContext(EvaluationContext<TItem> subContext) {
            this.subEvaluationContexts.Add(subContext);
        }

        private readonly List<List<ISentencePart>> sentenceParts = new List<List<ISentencePart>>();

        public IEnumerable<IEnumerable<ISentencePart>> SentenceParts {
            get { return this.sentenceParts; }
        }

        public void AddSentencePartList(IEnumerable<ISentencePart> sentencePartList) {
            this.sentenceParts.Add(sentencePartList.ToList());
        }

        public void AddSentencePartList(ISentencePart sentencePart) {
            this.AddSentencePartList(new[] { sentencePart });
        }

        public void AppendPartList(ISentencePart sentencePart) {
            this.AppendPartList(new[] { sentencePart });
        }

        public void AppendPartList(IEnumerable<ISentencePart> sentencePartList) {
            var newList = sentencePartList.ToList();

            if (!this.sentenceParts.Any()) {
                this.sentenceParts.Add(new List<ISentencePart>());
            }

            foreach (var list in this.sentenceParts) {
                list.AddRange(newList);
            }
        }

        public void AppendPartList(IEnumerable<IEnumerable<ISentencePart>> sentencePartListAlternatives) {
            if (!this.sentenceParts.Any()) {
                this.sentenceParts.Add(new List<ISentencePart>());
            }

            var existingSentenceParts = this.sentenceParts.ToList();
            sentencePartListAlternatives = sentencePartListAlternatives.ToList();

            foreach (var existingSentencePart in existingSentenceParts) {
                switch (sentencePartListAlternatives.Count()) {
                    case 0:
                        throw new InvalidOperationException("No sentence part to add");
                    case 1:
                        existingSentencePart.AddRange(sentencePartListAlternatives.Single());
                        break;
                    default:
                        foreach (var alternative in sentencePartListAlternatives.Skip(1)) {
                            var newAlternativeList = existingSentencePart.ToList();
                            newAlternativeList.AddRange(alternative);
                            this.sentenceParts.Add(newAlternativeList);
                        }

                        existingSentencePart.AddRange(sentencePartListAlternatives.First());
                        break;
                }
            }
        }

        public override string ToString() {
            return string.Join(" ", this.Words.Select(word => word.ToString()));
        }
    }
}
