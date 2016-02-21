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
    class ParticipePasseVerbDictionary : IDictionary {
        private readonly IEnumerable<IWordCategory> adverbs =
            Declare("devenir", "devenue", "devenu", "devenues", "devenus")
            .Union(Declare("entendre", "entendue", "entendu", "entendues", "entendus"))
            .Union(Declare("briser", "brisée", "brisé", "brisées", "brisés"))
            .Union(Declare("manquer", "manquée", "manqué", "manquées", "manqués"))
            .Union(Declare("droguer", "droguée", "drogué", "droguées", "drogués"))
            ;

        private static IEnumerable<IWordCategory> Declare(
            string verbId, string femSing, string mascSing, string femPlur, string mascPlus) {
            return new IWordCategory[] {
                new ParticipePasseVerb(femSing, verbId, Gender.Feminin, Number.Singular),
                new ParticipePasseVerb(mascSing, verbId, Gender.Masculin, Number.Singular),
                new ParticipePasseVerb(femPlur, verbId, Gender.Feminin, Number.Plural),
                new ParticipePasseVerb(mascPlus, verbId, Gender.Masculin, Number.Plural),
                new Adjective(femSing, Number.Singular, Gender.Feminin),
                new Adjective(mascSing, Number.Singular, Gender.Masculin),
                new Adjective(femPlur, Number.Plural, Gender.Feminin),
                new Adjective(mascPlus, Number.Plural, Gender.Masculin),
            };
        }

        public IEnumerable<string> GetAllWords() {
            return this.adverbs.Select(adverb => adverb.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adverbs.Where(adverb => adverb.Text == word.Value);
        }
    }
}
