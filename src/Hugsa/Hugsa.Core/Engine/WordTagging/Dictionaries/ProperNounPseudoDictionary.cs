using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.SyntaxAnalysis.Words.WordCategories;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries {
    class ProperNounPseudoDictionary : IDictionary {
        public IEnumerable<string> GetAllWords() {
            return Enumerable.Empty<string>();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            if (char.IsUpper(word.OriginalValue[0])) {
                return new[] { new ProperNoun(word.Value) };
            }
            else {
                return Enumerable.Empty<IWordCategory>();
            }
        }
    }
}
