using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;
using Hugsa.Core.Engine.WordTagging.WordCategories;

namespace Hugsa.Core.Engine.Dictionaries {
    class ConjunctionDictionary : IDictionary {
        private readonly IEnumerable<Conjunction> conjunctions = new[] {
            new Conjunction("mais", ConjunctionType.Coordination), 
            new Conjunction("ou", ConjunctionType.Coordination), 
            new Conjunction("et", ConjunctionType.Coordination), 
            new Conjunction("donc", ConjunctionType.Coordination), 
            new Conjunction("or", ConjunctionType.Coordination), 
            new Conjunction("ni", ConjunctionType.Coordination), 
            new Conjunction("car", ConjunctionType.Coordination), 
            new Conjunction("que", ConjunctionType.Subordination), 
            new Conjunction("qu", ConjunctionType.Subordination), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.conjunctions.Select(conjunction => conjunction.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.conjunctions.Where(conjunction => conjunction.Text == word.Value);
        }
    }
}
