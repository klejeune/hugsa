using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class NounDictionary : IDictionary {
        private IEnumerable<Noun> Nouns = new[] {
            new Noun("lapin", Number.Singular, Gender.Masculin),
            new Noun("lapins", Number.Plural, Gender.Masculin),
            new Noun("oreille", Number.Singular, Gender.Feminin),
            new Noun("oreilles", Number.Plural, Gender.Feminin),
            new Noun("mets", Number.Singular, Gender.Masculin),
            new Noun("mouton", Number.Singular, Gender.Masculin),
            new Noun("moutons", Number.Plural, Gender.Masculin),
            new Noun("petit", Number.Singular, Gender.Masculin),
            new Noun("petite", Number.Singular, Gender.Feminin),
            new Noun("petits", Number.Plural, Gender.Masculin),
            new Noun("petites", Number.Plural, Gender.Feminin),
            new Noun("journée", Number.Singular, Gender.Feminin),
            new Noun("journées", Number.Plural, Gender.Feminin),
            new Noun("paix", Number.Singular, Gender.Feminin),
            new Noun("écorce", Number.Singular, Gender.Feminin),
            new Noun("arbre", Number.Singular, Gender.Masculin),
            new Noun("situation", Number.Singular, Gender.Feminin),
            new Noun("traité", Number.Singular, Gender.Masculin),
            new Noun("trou", Number.Singular, Gender.Masculin),
            new Noun("trous", Number.Plural, Gender.Masculin),
            new Noun("délégation", Number.Singular, Gender.Masculin),
            new Noun("légumes", Number.Plural, Gender.Masculin),
            new Noun("légume", Number.Singular, Gender.Masculin),
            new Noun("navet", Number.Singular, Gender.Masculin),
            new Noun("navets", Number.Plural, Gender.Masculin),
            new Noun("odeur", Number.Singular, Gender.Feminin),
            new Noun("carottes", Number.Plural, Gender.Feminin),
        }
            .Union(DeclareNoun("époque", "époques", Gender.Feminin))
            .Union(DeclareNoun("arbre", "arbres", Gender.Feminin))
            .Union(DeclareNoun("potager", "potagers", Gender.Masculin))
            .Union(DeclareNoun("régime", "régimes", Gender.Masculin))
            .Union(DeclareNoun("bien", "biens", Gender.Masculin))
            .Union(DeclareNoun("peuple", "peuples", Gender.Masculin))
            .Union(DeclareNoun("escargot", "escargots", Gender.Masculin))
            .Union(DeclareNoun("forêt", "forêts", Gender.Feminin))
            .Union(DeclareNoun("homme", "hommes", Gender.Masculin))
            .Union(DeclareNoun("pied", "pieds", Gender.Masculin))
            .Union(DeclareNoun("semelle", "semelles", Gender.Masculin))
            .Union(DeclareNoun("géant", "géants", Gender.Masculin))
            .Union(DeclareNoun("coquille", "coquilles", Gender.Masculin))
            .Union(DeclareNoun("seconde", "secondes", Gender.Masculin))
            .Union(DeclareNoun("souci", "soucis", Gender.Masculin))
            .Union(DeclareNoun("liberté", "libertés", Gender.Feminin))
            .Union(DeclareNoun("fourré", "fourrés", Gender.Masculin))
            .Union(DeclareNoun("espace", "espaces", Gender.Masculin))
            .Union(DeclareNoun("brin", "brins", Gender.Masculin))
            .Union(DeclareNoun("chemin", "chemins", Gender.Masculin))
            .Union(DeclareNoun("herbe", "herbes", Gender.Feminin))
            .Union(DeclareNoun("ami", "amis", Gender.Masculin))
            .Union(DeclareNoun("amie", "amies", Gender.Feminin))
            .Union(DeclareNoun("monde", "mondes", Gender.Masculin))
            .Union(DeclareNoun("garde", "gardes", Gender.Masculin))
            .Union(DeclareNoun("garde", "gardes", Gender.Feminin))
            .Union(DeclareNoun("danger", "dangers", Gender.Masculin))
            .Union(DeclareNoun("embûche", "embûches", Gender.Feminin))
            .Union(DeclareNoun("ancêtre", "ancêtres", Gender.Masculin))
            .Union(DeclareNoun("troupeau", "troupeaux", Gender.Masculin))
            .Union(DeclareNoun("bataillon", "bataillons", Gender.Masculin))
            .Union(DeclareNoun("limace", "limaces", Gender.Feminin))
            .Union(DeclareNoun("course", "courses", Gender.Feminin))
            .Union(DeclareNoun("trace", "traces", Gender.Feminin))
            .Union(DeclareNoun("spectacle", "spectacles", Gender.Masculin))
            .Union(DeclareNoun("émoi", "émois", Gender.Masculin))
            .Union(DeclareNoun("habitant", "habitants", Gender.Masculin))
            .Union(DeclareNoun("allée", "allées", Gender.Feminin))
            .Union(DeclareNoun("sprinter", "sprinters", Gender.Masculin))
            .Union(DeclareNoun("bout", "bouts", Gender.Masculin))
            .Union(DeclareNoun("arrivée", "arrivées", Gender.Feminin))
            .Union(DeclareNoun("ligne", "lignes", Gender.Feminin))
            .Union(DeclareNoun("début", "débuts", Gender.Masculin))
            .Union(DeclareNoun("classe", "classes", Gender.Feminin))
            .Union(DeclareNoun("souris", "souris", Gender.Feminin))
            .Union(DeclareNoun("chat", "chats", Gender.Masculin))
            .Union(DeclareNoun("chatte", "chattes", Gender.Feminin))
            .Union(DeclareNoun("fille", "filles", Gender.Feminin))
            .Union(DeclareNoun("ours", "ours", Gender.Masculin))
            .Union(DeclareNoun("drogué", "drogués", Gender.Masculin))
            .Union(DeclareNoun("droguée", "droguées", Gender.Feminin))
            .Union(DeclareNoun("mère", "mères", Gender.Feminin))
            .Union(DeclareNoun("pute", "putes", Gender.Feminin))
            .Union(DeclareNoun("con", "cons", Gender.Masculin))
            .Union(DeclareNoun("conne", "connes", Gender.Feminin))

            ;

        private static IEnumerable<Noun> DeclareNoun(string singular, string plural, Gender gender) {
            var list = new List<Noun>();

            if (!string.IsNullOrEmpty(singular)) {
                list.Add(new Noun(singular, Number.Singular, gender));
            }
            
            if (!string.IsNullOrEmpty(plural)) {
                list.Add(new Noun(plural, Number.Plural, gender));
            }

            return list;
        }

        public IEnumerable<string> GetAllWords() {
            return this.Nouns.Select(noun => noun.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.Nouns.Where(noun => noun.Text == word.Value);
        }
    }
}
