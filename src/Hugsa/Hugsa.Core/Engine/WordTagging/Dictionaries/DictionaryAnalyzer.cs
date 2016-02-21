using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.Dictionaries;

namespace Hugsa.Core.Engine.Dictionaries {
    class DictionaryAnalyzer {
        private readonly IEnumerable<IDictionary> dictionaries = BuildDictionaries();


        private static IEnumerable<IDictionary> BuildDictionaries() {
            var adverbs = new AdverbDictionary();
            var determinants = new DeterminantDictionary();

            return new IDictionary[] {
                adverbs,
                new VerbDictionary(),
                new NounDictionary(),
                new AdjectiveDictionary(),
                determinants,
                new PrepositionDictionary(),
                new ConjunctionDictionary(),
                new PersonalPronounDictionary(),
                new AdjectifPossessifDictionary(),
                new RelativePronounDictionary(),
                new NumeralAdjectiveDictionary(),
                new ContractionDictionary(adverbs, determinants),
                new NegationDictionary(), 
                new DemonstrativePronounDictionary(), 
                new QuantifierDictionary(), 
                new ParticipePasseVerbDictionary(),
                new ProperNounPseudoDictionary(),
            };
        }

        public DictionaryAnalysisReport Analyze(TextAnalysisReport analysisReport) {
            var known = new List<Word>();
            var unknown = new List<Word>();
            var categorizedWords = new List<KeyValuePair<string, IEnumerable<IWordCategory>>>();

            foreach (var sentence in analysisReport.Sentences) {
                foreach (var word in sentence.Words) {
                    word.KnownMatchingCategories = dictionaries.SelectMany(dictionary => dictionary.GetMatchingWords(word)).ToList();
                    categorizedWords.Add(new KeyValuePair<string, IEnumerable<IWordCategory>>(word.OriginalValue, word.KnownMatchingCategories));

                    if (word.KnownMatchingCategories.Any()) {
                        known.Add(word);
                    }
                    else {
                        unknown.Add(word);
                    }
                }
            }

            return new DictionaryAnalysisReport {
                KnownWords = known,
                UnknownWords = unknown,
                WordCategories = categorizedWords,
            };
        }
    }
}
