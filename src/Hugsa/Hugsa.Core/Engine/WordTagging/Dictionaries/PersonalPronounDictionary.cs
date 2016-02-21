using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging.WordCategories;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.WordTagging.Dictionaries {
    class PersonalPronounDictionary : IDictionary {
        private readonly IEnumerable<PersonalPronoun> determinants = new[] {
            new PersonalPronoun("je", Person.First, Cas.Nominatif, Gender.Undefined, Number.Singular), 
            new PersonalPronoun("tu", Person.First, Cas.Nominatif, Gender.Undefined, Number.Singular), 
            new PersonalPronoun("il", Person.First, Cas.Nominatif, Gender.Masculin, Number.Singular), 
            new PersonalPronoun("on", Person.First, Cas.Nominatif, Gender.Undefined, Number.Singular), 
            new PersonalPronoun("elle", Person.First, Cas.Nominatif, Gender.Feminin, Number.Singular), 
            new PersonalPronoun("nous", Person.First, Cas.Nominatif, Gender.Undefined, Number.Plural), 
            new PersonalPronoun("vous", Person.First, Cas.Nominatif, Gender.Undefined, Number.Plural), 
            new PersonalPronoun("ils", Person.First, Cas.Nominatif, Gender.Masculin, Number.Plural), 
            new PersonalPronoun("elles", Person.First, Cas.Nominatif, Gender.Feminin, Number.Plural), 
            new PersonalPronoun("y", Person.Undefined, Cas.Undefined, Gender.Undefined, Number.Undefined), 
            new PersonalPronoun("se", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Singular), 
            new PersonalPronoun("se", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Singular), 
            new PersonalPronoun("se", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Plural), 
            new PersonalPronoun("se", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Plural), 
            new PersonalPronoun("s", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Singular), 
            new PersonalPronoun("s", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Singular), 
            new PersonalPronoun("s", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Plural), 
            new PersonalPronoun("s", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Plural), 
            new PersonalPronoun("lui", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Singular), 
            new PersonalPronoun("elle", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Singular), 
            new PersonalPronoun("eux", Person.Third, Cas.Accusatif, Gender.Masculin, Number.Plural), 
            new PersonalPronoun("elles", Person.Third, Cas.Accusatif, Gender.Feminin, Number.Plural), 
            new PersonalPronoun("lui", Person.Third, Cas.Oblique, Gender.Masculin, Number.Singular), 
            new PersonalPronoun("elle", Person.Third, Cas.Oblique, Gender.Feminin, Number.Singular), 
            new PersonalPronoun("eux", Person.Third, Cas.Oblique, Gender.Masculin, Number.Plural), 
            new PersonalPronoun("elles", Person.Third, Cas.Oblique, Gender.Feminin, Number.Plural), 
        };

        public IEnumerable<string> GetAllWords() {
            return this.determinants.Select(determinant => determinant.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.determinants.Where(determinant => determinant.Text == word.Value);
        }
    }
}
