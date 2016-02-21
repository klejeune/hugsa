using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    class VerbDictionary : IDictionary {
        private readonly IEnumerable<Verb> conjugations =
            new []{new Verb("voilà","voilà", Person.Infinitive, Number.Undefined, Temps.Undefined)}
            .Union(DefinePresentVerb("être", "être", "étant", "suis", "es", "est", "sommes", "êtes", "sont"))
                .Union(DefineImparfaitVerb("être", "étais", "étais", "était", "étions", "étiez", "étaient"))
                .Union(DefinePresentVerb("avoir", "avoir", "ayant", "ai", "as", "a", "avons", "avez", "ont"))
                .Union(DefinePresentVerb("livrer", "livrer", "livrant", "livre", "livres", "livre", "livrons", "livrez", "livrent"))
                .Union(DefinePresentVerb("aimer", "aimer", "aimant", "aime", "aimes", "aime", "aimons", "aimez", "aiment"))
                .Union(DefinePresentVerb("laisser", "laisser", "laissant", "laisse", "laisses", "laisse", "laissons", "laissez", "laissent"))
                .Union(DefinePresentVerb("vomir", "vomir", "vomissant", "vomis", "vomis", "vomit", "vomissons", "vomissez", "vomissent"))
                .Union(DefinePresentVerb("tenir", "tenir", "tenant", "tiens", "tiens", "tient", "tenons", "tenez", "tiennent"))
                .Union(DefinePresentVerb("regarder", "regarder", "regardant", "regarde", "regardes", "regarde", "regardons", "regardez", "regardent"))
                .Union(DefinePresentVerb("pleurer", "pleurer", "pleurant", "pleure", "pleures", "pleure", "pleurons", "pleurez", "pleurent"))
                .Union(DefinePresentVerb("passer", "passer", "passant", "passe", "passes", "passe", "passons", "passez", "passent"))
                .Union(DefineImparfaitVerb("avoir", "avais", "avais", "avait", "avions", "aviez", "avaient"))
                .Union(DefinePresentVerb("changer", "changer", "changeant", "change", "changes", "change", "changeons", "changez", "changent"))
                .Union(DefinePresentVerb("signer", "signer", "signant", "signe", "signes", "signe", "signons", "signez", "signent"))
                .Union(DefinePresentVerb("cultiver", "cultiver", "cultivant", "cultive", "cultives", "cultive", "cultivons", "cultivez", "cultivent"))
                .Union(DefinePresentVerb("protéger", "protéger", "protégeant", "protége", "protéges", "protége", "protégeons", "protégez", "protégent"))
                .Union(DefinePresentVerb("faire", "faire", "faisant", "faisais", "faisais", "faisait", "faisons", "faîtes", "font"))
                .Union(DefinePresentVerb("mordre", "mordre", "mordant", "mords", "mords", "mord", "mordons", "mordez", "mordent"))
                .Union(DefinePresentVerb("partir", "partir", "partant", "pars", "pars", "part", "partons", "partez", "partent"))
                .Union(DefinePresentVerb("mettre", "mettre", "mettant", "mets", "mets", "met", "mettons", "mettez", "mettent"))
                .Union(DefinePresentVerb("réfléchir", "réfléchir", "réfléchissant", "réfléchis", "réfléchis", "réfléchit", "réfléchissons", "réfléchissez", "réfléchissent"))
                .Union(DefinePresentVerb("pousser", "pousser", "poussant", "pousse", "pousses", "pousse", "poussons", "poussez", "poussent"))
                .Union(DefinePresentVerb("sucer", "sucer", "suçant", "suce", "suces", "suce", "suçons", "sucez", "sucent"))
                .Union(DefinePresentVerb("manger", "manger", "mangeant", "mange", "manges", "mange", "mangeons", "mangez", "mangent"))
                .Union(DefinePresentVerb("piétiner", "piétiner", "piétinant", "piétine", "piétines", "piétine", "piétinons", "piétinez", "piétinent"))
                .Union(DefinePresentVerb("bâiller", "bâiller", "bâillant", "bâille", "bâilles", "bâille", "bâillons", "bâillez", "bâillent"))
                .Union(DefinePresentVerb("parler", "parler", "parlant", "parle", "parles", "parle", "parlons", "parlez", "parlent"))
                .Union(DefinePresentVerb("voyager", "voyager", "voyagant", "voyage", "voyages", "voyage", "voyagons", "voyagez", "voyagent"))
                .Union(DefinePresentVerb("saluer", "saluer", "saluant", "salue", "salues", "salue", "saluons", "saluez", "saluent"))
                .Union(DefinePresentVerb("découvrir", "découvrir", "découvrant", "découvre", "découvres", "découvre", "découvrons", "découvrez", "découvrent"))
                .Union(DefinePresentVerb("entrer", "entrer", "entrant", "entre", "entres", "entre", "entrons", "entrez", "entrent"))
                .Union(DefinePresentVerb("écrabouiller", "écrabouiller", "écrabouillant", "écrabouille", "écrabouilles", "écrabouille", "écrabouillons", "écrabouillez", "écrabouillent"))
                .Union(DefinePasseSimpleVerb("rencontrer", "rencontrai", "rencontras", "rencontra", "rencontrâmes", "rencontrâtes", "rencontrèrent"))
                .Union(DefinePasseSimpleVerb("répandre", "répandis", "répandis", "répandit", "répandîmes", "répandîtes", "répandirent"))
                .Union(DefineImparfaitVerb("faire", "faisais", "faisais", "faisait", "faisions", "faisiez", "faisaient"))
                .Union(DefineImparfaitVerb("désirer", "désirais", "désirais", "désirait", "désirions", "désiriez", "désiraient"))
                .Union(DefineImparfaitVerb("finir", "finissais", "finissais", "finissait", "finissions", "finissiez", "finissaient"))
                .Union(DefineImparfaitVerb("rêver", "rêvais", "rêvais", "rêvait", "rêvions", "rêviez", "rêvaient"))
                .Union(DefineImparfaitVerb("ennuyer", "ennuyais", "ennuyais", "ennuyait", "ennuyions", "ennuyiez", "ennuyaient"))
                .Union(DefineImparfaitVerb("voiloir", "voulais", "voulais", "voulait", "voulions", "vouliez", "voulaient"))
                .Union(DefineImparfaitVerb("connaisser", "connaissais", "connaissais", "connaissait", "connaissions", "connaissiez", "connaissaient"))
                .Union(DefinePresentVerb("installer", "installer", "installant", "installe", "installes", "installe", "installons", "installez", "installent"))
                .Union(DefineImparfaitVerb("installer", "installais", "installais", "installait", "installions", "installiez", "installaient"))
                .Union(DefineImparfaitVerb("battre", "battais", "battais", "battait", "battions", "battiez", "battaient"))
                .Union(DefineImparfaitVerb("passer", "passais", "passais", "passait", "passions", "passiez", "passaient"))
                .Union(DefinePresentVerb("semer", "semer", "semant", "sème", "sèmes", "sème", "semons", "semez", "sèmment"))
                .Union(DefineImparfaitVerb("semer", "semais", "semais", "semait", "semions", "semiez", "semaient"))
                .Union(DefinePasseSimpleVerb("semer", "semai", "semas", "sema", "semâmes", "semâtes", "semèrent"))
                .Union(DefinePasseSimpleVerb("décider", "décidai", "décidas", "décida", "décidâmes", "décidâtes", "décidèrent"))
                .Union(DefinePasseSimpleVerb("mettre", "mis", "mis", "mit", "mîmes", "mîtes", "mirent"))
                .Union(DefineImparfaitVerb("vivre", "vivais", "vivais", "vivait", "vivions", "viviez", "vivaient"))
                .Union(DefineImparfaitVerb("aimer", "aimais", "aimais", "aimait", "aimions", "aimiez", "aimaient"))
                ;

        private static IEnumerable<Verb> DefinePresentVerb(
            string id, string infinitive, string participePresent, string firstSingular, string secondSingular, string thirdSingular, string firstPlural,
            string secondPlural, string thirdPlural) {
            return new[] {
                new Verb(infinitive, id, Person.Infinitive, Number.Undefined, Temps.Undefined),
                new Verb(participePresent, id, Person.ParticipePresent, Number.Undefined, Temps.Undefined),
            }
                .Union(
                    DefineVerbWithTemps(
                        id, Temps.Present, firstSingular, secondSingular, thirdSingular, firstPlural, secondPlural,
                        thirdPlural));
        }

        private static IEnumerable<Verb> DefinePasseSimpleVerb(
            string id, string firstSingular, string secondSingular, string thirdSingular, string firstPlural,
            string secondPlural, string thirdPlural) {
            return DefineVerbWithTemps(
                id, Temps.PasseSimple, firstSingular, secondSingular, thirdSingular, firstPlural, secondPlural,
                thirdPlural);
        }

        private static IEnumerable<Verb> DefineImparfaitVerb(
            string id, string firstSingular, string secondSingular, string thirdSingular, string firstPlural,
            string secondPlural, string thirdPlural) {
            return DefineVerbWithTemps(
                id, Temps.Imparfait, firstSingular, secondSingular, thirdSingular, firstPlural, secondPlural,
                thirdPlural);
        }

        private static IEnumerable<Verb> DefineVerbWithTemps(
            string id, Temps temps, string firstSingular, string secondSingular, string thirdSingular, string firstPlural,
            string secondPlural, string thirdPlural) {
            return new[] {
                new Verb(firstSingular, id, Person.First, Number.Singular, temps),
                new Verb(secondSingular, id, Person.Second, Number.Singular, temps),
                new Verb(thirdSingular, id, Person.Third, Number.Singular, temps),
                new Verb(firstPlural, id, Person.First, Number.Plural,temps),
                new Verb(secondPlural, id, Person.Second, Number.Plural, temps),
                new Verb(thirdPlural, id, Person.Third, Number.Plural, temps),
            };
        }

        public IEnumerable<string> GetAllWords() {
            return this.conjugations.Select(conjugation => conjugation.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.conjugations.Where(conjugation => conjugation.Text == word.Value);
        }
    }
}
