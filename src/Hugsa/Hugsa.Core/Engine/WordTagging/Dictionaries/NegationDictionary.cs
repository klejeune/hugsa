using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.WordTagging.Dictionaries {
    class NegationDictionary : IDictionary {
        private readonly IEnumerable<Negation> particules = new[] {
            new Negation("ne"), 
            new Negation("n"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.particules.Select(particule => particule.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.particules.Where(particule => particule.Text == word.Value);
        }
    }
}
