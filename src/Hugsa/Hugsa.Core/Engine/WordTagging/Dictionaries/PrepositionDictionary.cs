using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class PrepositionDictionary : IDictionary {
        private readonly IEnumerable<Preposition> prepositions = new[] {
            new Preposition("dans"), 
            new Preposition("d"), 
            new Preposition("de"), 
            new Preposition("avec"), 
            new Preposition("sans"), 
            new Preposition("en"), 
            new Preposition("à"), 
            new Preposition("pour"), 
            new Preposition("sur"), 
            new Preposition("avant"), 
            new Preposition("sous"), 
            new Preposition("derrière"),
            new Preposition("jusqu"), 
            new Preposition("jusque"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.prepositions.Select(preposition => preposition.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.prepositions.Where(preposition => preposition.Text == word.Value);
        }
    }
}
