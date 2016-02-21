using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class NumeralAdjectiveDictionary : IDictionary {
        private readonly IEnumerable<NumeralAdjective> adjectives = new[] {
            new NumeralAdjective("un", Gender.Masculin), 
            new NumeralAdjective("une", Gender.Feminin), 
            new NumeralAdjective("deux", Gender.Undefined), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.adjectives.Select(adjective => adjective.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adjectives.Where(adjective => adjective.Text == word.Value);
        }
    }
}
