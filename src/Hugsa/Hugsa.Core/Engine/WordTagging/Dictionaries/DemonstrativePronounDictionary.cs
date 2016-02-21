using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class DemonstrativePronounDictionary : IDictionary {
        private readonly IEnumerable<DemonstrativePronoun> pronouns = new[] {
            new DemonstrativePronoun("cela"), 
            new DemonstrativePronoun("ce"), 
            new DemonstrativePronoun("c"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.pronouns.Select(pronoun => pronoun.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.pronouns.Where(pronoun => pronoun.Text == word.Value);
        }
    }
}
