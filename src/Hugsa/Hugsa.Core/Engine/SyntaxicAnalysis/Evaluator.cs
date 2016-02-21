using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public  class Evaluator<TItem, TContext> {
        private static TableComputer tableComputer = new TableComputer();
        private IEnumerable<TItem> Words { get; set; }
        public TContext Context { get; private set; }

        public Evaluator(IEnumerable<TItem> words, TContext context) {
            this.Words = words;
            this.Context = context;
        }

        public EvaluationContext<TItem> GetBaseContext() {
            var baseContext = new EvaluationContext<TItem>(this.Words);

            return baseContext;
        }

        public void EvaluateOr(
            EvaluationContext<TItem> evaluationContext,
            params Func<EvaluationContext<TItem>, Evaluator<TItem, TContext>, bool>[] evaluationFunc) {
            if (!evaluationFunc.Any(
                func => {
                    try {
                        var newEvaluationContext = new EvaluationContext<TItem>(evaluationContext.Words);

                        if (func(newEvaluationContext, this)) {

                            foreach (var sentencePartList in newEvaluationContext.SentenceParts) {
                                evaluationContext.AddSentencePartList(sentencePartList);
                            }

                            return true;
                        }
                        else {
                            return false;
                        }
                    } catch (UnrecognizedPhraseException) {
                        return false;
                    }
                })) {
                throw new UnrecognizedPhraseException();
            }
        }

        public void EvaluateAnd(
            EvaluationContext<TItem> evaluationContext,
            params Func<EvaluationContext<TItem>, Evaluator<TItem, TContext>, bool>[] evaluationFunc) {

            var table = tableComputer.Compute(evaluationContext.Words.Count(), evaluationFunc.Count());

            var funcList = table.Select<int[], Func<EvaluationContext<TItem>, Evaluator<TItem, TContext>, bool>>(
                row =>
                    (context, evaluator) => {
                        this.EvaluateFixedAnd(
                            context,
                            row.Select(
                                (value, index) =>
                                    new KeyValuePair
                                        <Func<EvaluationContext<TItem>, Evaluator<TItem, TContext>, bool>, int>(
                                        evaluationFunc[index], value)));
                        return true;
                    }
                ).ToArray();

            this.EvaluateOr(evaluationContext, funcList);
        }
        
        public void EvaluateFixedAnd(EvaluationContext<TItem> evaluationContext, IEnumerable<KeyValuePair<Func<EvaluationContext<TItem>, Evaluator<TItem, TContext>, bool>, int>> evaluationFunc) {
            int wordOffset = 0;

            foreach (var funcPair in evaluationFunc) {
                var newEvaluationContext = new EvaluationContext<TItem>(evaluationContext.Words.Skip(wordOffset).Take(funcPair.Value));

                if (!funcPair.Key(newEvaluationContext, this)) {
                    throw new UnrecognizedPhraseException();
                }

                evaluationContext.AppendPartList(newEvaluationContext.SentenceParts);

                wordOffset += funcPair.Value;
            }

            if (wordOffset != evaluationContext.Words.Count()) {
                throw new InvalidOperationException("We computed on the wrong number of words!");
            }
        }

        public void SetResult<TResult>(TResult result) {

        }

        public IEnumerable<TResult> GetPossibilities<TResult>() {
            return Enumerable.Empty<TResult>();
        }
    }
}
