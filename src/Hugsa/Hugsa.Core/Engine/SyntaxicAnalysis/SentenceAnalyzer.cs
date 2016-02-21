using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Memories;
using Hugsa.Core.Engine.SyntaxicAnalysis.Expressions;
using Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class SentenceAnalyzer {
        public SentenceAnalysisReport Analyze(TextAnalysisReport taggingReport) {

            IEnumerable<IEnumerable<ISentencePart>> analyzedSentences;
            string errorMessage = string.Empty;

            try {
                analyzedSentences = taggingReport.Sentences.Select(sentence => this.AnalyzeSentence(sentence)).ToList();
            } catch (InvalidOperationException exception) {
                analyzedSentences = null;
                errorMessage = exception.Message;
            }

            return new SentenceAnalysisReport {
                SentenceParts = analyzedSentences,
                ErrorMessage =  errorMessage,
            };
        }

        private IEnumerable<ISentencePart> AnalyzeSentence(Sentence sentence) {
            var evaluator = new Evaluator<Word, SentenceContext>(sentence.Words, new SentenceContext());
            var context = evaluator.GetBaseContext();

            IEnumerable<IEnumerable<ISentencePart>> possibilities;

            try {
                evaluator.EvaluateAnd(context, PropositionExpressions.AnalyzeProposition, PropositionExpressions.AnalyzeProposition);
                possibilities = context.SentenceParts;
            } catch (UnrecognizedPhraseException) {
                possibilities = new List<IEnumerable<ISentencePart>>();
            }

            if (possibilities.Count() >= 2) {
                throw new InvalidOperationException("Expression ambiguë : <" + string.Join(" ", sentence.Words.Select(word => word.OriginalValue)) + ">");
            }

            if (!possibilities.Any()) {
                throw new InvalidOperationException("Structure agrammaticale : <" + string.Join(" ", sentence.Words.Select(word => word.OriginalValue)) + ">");
            }

            return possibilities.Single();
        }



      
      
    }
}
