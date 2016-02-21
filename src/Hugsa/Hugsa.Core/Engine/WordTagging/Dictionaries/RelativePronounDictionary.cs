using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.Dictionaries {
    class RelativePronounDictionary : IDictionary {
        private readonly IEnumerable<RelativePronoun> pronouns = new[] {
            new RelativePronoun("qui"), 
            new RelativePronoun("lequel"), 
            new RelativePronoun("laquelle"), 
            new RelativePronoun("lesquels"), 
            new RelativePronoun("lesquelles"), 
            new RelativePronoun("dont"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.pronouns.Select(pronoun => pronoun.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.pronouns.Where(pronoun => pronoun.Text == word.Value);
        }
    }
}
