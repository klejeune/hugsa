using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries {
    class AdjectifPossessifDictionary : IDictionary {
        private readonly IEnumerable<AdjectifPossessif> adjectifsPossessifs = new[] {
            new AdjectifPossessif("leur"), 
            new AdjectifPossessif("leurs"), 
            new AdjectifPossessif("mon"), 
            new AdjectifPossessif("ma"), 
            new AdjectifPossessif("mes"), 
            new AdjectifPossessif("ton"), 
            new AdjectifPossessif("ta"), 
            new AdjectifPossessif("tes"), 
            new AdjectifPossessif("son"), 
            new AdjectifPossessif("sa"), 
            new AdjectifPossessif("ses"), 
            new AdjectifPossessif("notre"), 
            new AdjectifPossessif("nos"), 
            new AdjectifPossessif("votre"), 
            new AdjectifPossessif("vos"), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.adjectifsPossessifs.Select(adjectifPossessif => adjectifPossessif.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adjectifsPossessifs.Where(adjectifPossessif => adjectifPossessif.Text == word.Value);
        }

    }
}
