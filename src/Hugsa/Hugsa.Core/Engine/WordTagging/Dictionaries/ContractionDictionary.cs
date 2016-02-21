using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class ContractionDictionary : IDictionary {
        public ContractionDictionary(AdverbDictionary adverbs, DeterminantDictionary determinants) {

            contractions = new[] {
                DeclareContraction("aux", true, adverbs.GetMatchingWords(new Word("à")).Single(), determinants.GetMatchingWords(new Word("les")).Single()),
                DeclareContraction("au", true, adverbs.GetMatchingWords(new Word("à")).Single(), determinants.GetMatchingWords(new Word("le")).Single()),                
            };
        }

        private readonly IEnumerable<Contraction> contractions; 

        private static Contraction DeclareContraction(string text, bool isCompulsory, params IWordCategory[] replacements) {
            return new Contraction(text, replacements, isCompulsory);
        }

        public IEnumerable<string> GetAllWords() {
            return this.contractions.Select(contraction => contraction.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.contractions.Where(contraction => contraction.Text == word.Value);
        }
    }
}
