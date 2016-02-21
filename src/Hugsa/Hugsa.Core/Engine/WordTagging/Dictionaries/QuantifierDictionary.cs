using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.WordTagging.Dictionaries {
    class QuantifierDictionary : IDictionary {
        private readonly IEnumerable<Quantifier> adjectives = new[] {
            new Quantifier("du"), 
            new Quantifier("des"), 
            new Quantifier("chaque"), 
            new Quantifier("tout"), 
            new Quantifier("tous"), 
            new Quantifier("toutes"), 
            new Quantifier("quelque"), 
            new Quantifier("quelques"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.adjectives.Select(adjective => adjective.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adjectives.Where(adjective => adjective.Text == word.Value);
        }
    }
}
