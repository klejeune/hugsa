using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.SyntaxAnalysis.Words.WordCategories;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.SyntaxAnalysis.Words.Dictionaries {
    class DeterminantDictionary : IDictionary {
        private readonly IEnumerable<Determinant> determinants = new[] {
            new Determinant("un", true, Gender.Undefined, Number.Singular), 
            new Determinant("l", true, Gender.Undefined, Number.Singular), 
            new Determinant("le", true, Gender.Masculin, Number.Singular), 
            new Determinant("la", true, Gender.Feminin, Number.Singular), 
            new Determinant("les", true, Gender.Undefined, Number.Plural), 
            new Determinant("du", false, Gender.Masculin, Number.Singular), 
            new Determinant("des", false, Gender.Undefined, Number.Plural), 
            new Determinant("ce", true, Gender.Masculin, Number.Singular), 
            new Determinant("cet", true, Gender.Masculin, Number.Singular), 
            new Determinant("cette", true, Gender.Feminin, Number.Singular), 
            new Determinant("ces", true, Gender.Masculin, Number.Plural), 
            new Determinant("cettes", true, Gender.Feminin, Number.Plural), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.determinants.Select(determinant => determinant.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.determinants.Where(determinant => determinant.Text == word.Value);
        }
    }
}
