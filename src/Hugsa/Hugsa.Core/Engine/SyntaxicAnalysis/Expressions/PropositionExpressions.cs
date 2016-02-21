using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.Expressions {
    class PropositionExpressions {
        public static bool AnalyzeProposition(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateOr(evaluationContext, 
                AnalyzePrincipalProposition, 
                AnalyzeTimeProposition);
            //evaluationContext.AddSentencePartList(new Subject(evaluationContext.Words).AsArray());

            return true;
        }

        public static bool AnalyzePrincipalProposition(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateOr(evaluationContext,
                AnalyzeSubjectVerb,
                AnalyzeSubjectCopuleVerb,
                AnalyzeSubjectVerbComplement);

            return true;
        }

        public static bool AnalyzeTimeProposition(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateAnd(evaluationContext, AnalyseIlya, AnalyzeTimespan);

            return true;
        }

        public static bool AnalyseIlya(
            EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            if (string.Join(" ", evaluationContext.Words.Select(word => word.Value)) == "il y a") {
                evaluationContext.AddSentencePartList(new TimespanIntroductionPart(evaluationContext.Words));
                return true;
            }

            return false;
        }

        public static bool AnalyzeTimespan(
            EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            var isValid = evaluationContext.Words
                .Take(evaluationContext.Words.Count() - 1)
                .All(word => word.KnownMatchingCategories.Any(category => category.Type == WordCategoryType.Adverb && new[] { AdverbType.Superlative, AdverbType.Comparative }.Contains((category as Adverb).AdverbType)))
                && 
                evaluationContext
                .Words
                .Last()
                .KnownMatchingCategories
                .Any(category => category.Type == WordCategoryType.Adverb && (category as Adverb).AdverbType == AdverbType.Timespan);

            if (isValid) {
                evaluationContext.AddSentencePartList(new TimespanSentencePart(evaluationContext.Words));
                return true;
            }

            return false;
        }

        public static bool AnalyzeSubjectVerb(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateAnd(evaluationContext, AnalyzeSubject, AnalyzeVerb);
            return true;
        }

        public static bool AnalyzeSubjectVerbComplement(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateAnd(evaluationContext, AnalyzeSubject, AnalyzeVerb, AnalyzeNominalPhrase);
            return true;
        }

        public static bool AnalyzeSubjectCopuleVerb(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateAnd(evaluationContext, AnalyzeSubject, AnalyzeCopuleVerb, AnalyzeAfterCopule);
            return true;
        }

        public static bool AnalyzeAfterCopule(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateOr(evaluationContext, AnalyzeSubjectAttribute, AnalyzeNominalPhrase);
            return true;
        }

        public static bool AnalyzeSubject(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            evaluator.EvaluateOr(evaluationContext, AnalyzeNominalPhrase);
            //evaluationContext.AddSentencePartList(new Subject(evaluationContext.Words).AsArray());

            return true;
        }

        public static bool AnalyzeVerb(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            var words = evaluationContext.Words.ToList();

            if (words.Count() != 1
                || !words.Single().KnownMatchingCategories.Any(category => category.Type == WordCategoryType.Verb)) {
                throw new UnrecognizedPhraseException();
            }

            evaluationContext.AddSentencePartList(new VerbPart(words.Single()));
            return true;
        }

        public static bool AnalyzeCopuleVerb(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            var words = evaluationContext.Words.ToList();

            if (words.Count() != 1
                || !words.Single().KnownMatchingCategories.Any(category => category.Type == WordCategoryType.Verb && (category as Verb).VerbId == "être")) {
                throw new UnrecognizedPhraseException();
            }

            evaluationContext.AddSentencePartList(new VerbPart(words.Single()));
            return true;
        }

        public static bool AnalyzeSubjectAttribute(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            var words = evaluationContext.Words.ToList();

            if (words.Count() != 1
                || !words.Single().KnownMatchingCategories.Any(category => category.Type == WordCategoryType.Adjective)) {
                throw new UnrecognizedPhraseException();
            }

            evaluationContext.AddSentencePartList(new SubjectAttribute(words));
            return true;
        }

        public static bool AnalyzeNominalPhrase(EvaluationContext<Word> evaluationContext, Evaluator<Word, SentenceContext> evaluator) {
            Word noun = null;
            var adjectives = new List<Word>();
            Word determinant = null;

            foreach (var word in evaluationContext.Words.Select((value, index) => new { value, index })) {
                if (word.index == 0 && word.value.KnownMatchingCategories.Any(category => category.Type == WordCategoryType.Determinant)) {
                    determinant = word.value;
                }
                else if (word.value.MayBe(WordCategoryType.Noun, WordCategoryType.ProperNoun) && noun == null) {
                    noun = word.value;
                }
                else if (word.value.MayBe(WordCategoryType.Adjective)) {
                    adjectives.Add(word.value);
                }
                else {
                    throw new UnrecognizedPhraseException();
                }
            }

            evaluationContext.AppendPartList(new NominalPhrase(determinant, noun, adjectives));

            return true;
        }

    }
}
