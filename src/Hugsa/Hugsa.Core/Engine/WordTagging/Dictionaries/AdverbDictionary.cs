using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries {
    class AdverbDictionary : IDictionary{
        private readonly IEnumerable<Adverb> adverbs = new[] {
            new Adverb("longtemps", AdverbType.Timespan), 
            new Adverb("là", AdverbType.Location), 
            new Adverb("à", AdverbType.Undefined), 
            new Adverb("très", AdverbType.Undefined), 
            new Adverb("alors", AdverbType.Undefined), 
            new Adverb("comme", AdverbType.Undefined), 
            new Adverb("plus", AdverbType.Comparative), 
            new Adverb("tout", AdverbType.Undefined), 
            new Adverb("bien", AdverbType.Superlative), 
            new Adverb("cependant", AdverbType.Undefined), 
            new Adverb("pas", AdverbType.Undefined), 
            new Adverb("pourquoi", AdverbType.Interrogation), 
            new Adverb("au-delà", AdverbType.Location), 
            new Adverb("ailleurs", AdverbType.Location), 
            new Adverb("déjà", AdverbType.Time), 
            new Adverb("enfin", AdverbType.Time), 
            new Adverb("tard", AdverbType.Time), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.adverbs.Select(adverb => adverb.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adverbs.Where(adverb => adverb.Text == word.Value);
        }
    }
}
