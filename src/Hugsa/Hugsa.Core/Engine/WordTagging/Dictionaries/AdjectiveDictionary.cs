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
    public class AdjectiveDictionary : IDictionary {
        private readonly IEnumerable<Adjective> adjectives = new[] {
            new Adjective("frais", Number.Singular, Gender.Masculin), 
            new Adjective("recherché", Number.Singular, Gender.Masculin), 
            new Adjective("recherchée", Number.Singular, Gender.Feminin), 
            new Adjective("recherchés", Number.Plural, Gender.Masculin), 
            new Adjective("recherchées", Number.Plural, Gender.Feminin), 
            new Adjective("signée", Number.Singular, Gender.Feminin), 
        }
        .Union(DefineAdjective("ronde", "rond", "rondes", "ronds"))
        .Union(DefineAdjective("minuscule", "minuscule", "minuscules", "minuscules"))
        .Union(DefineAdjective("unique", "unique", "uniques", "uniques"))
        .Union(DefineAdjective("féroce", "féroce", "féroces", "féroces"))
        .Union(DefineAdjective("insupportable", "insupportable", "insupportables", "insupportables"))
        .Union(DefineAdjective("succulente", "succulent", "succulentes", "succulents"))
        .Union(DefineAdjective("merveilleuse", "merveilleux", "merveilleuses", "merveilleux"))
        .Union(DefineAdjective("secrète", "secret", "secrètes", "secrets"))
        .Union(DefineAdjective("heureuse", "heureux", "heureuses", "heureux"))
        .Union(DefineAdjective("lourde", "lourd", "lourdes", "lourds"))
        .Union(DefineAdjective("grande", "grand", "grandes", "grands"))
        .Union(DefineAdjective("dangereuse", "dangereux", "dangereuses", "dangereux"))
        .Union(DefineAdjective("remplie", "rempli", "remplis", "remplies"))
        .Union(DefineAdjective("imprévisible", "imprévisible", "imprévisibles", "imprévisibles"))
        .Union(DefineAdjective("acharnée", "acharné", "acharnées", "acharnés"))
        .Union(DefineAdjective("craspouille", "craspouille", "craspouilles", "craspouilles"))
        .Union(DefineAdjective("première", "premier", "premières", "premiers"))
        .Union(DefineAdjective("jeune", "jeune", "jeunes", "jeunes"))
        .Union(DefineAdjective("jolie", "joli", "jolies", "jolis"))
        .Union(DefineAdjective("vieille", "vieux", "vieilles", "vieux"))
        .Union(DefineAdjective("petite", "petit", "petites", "petits"))
        .Union(DefineAdjective("conne", "con", "connes", "cons"))
        .Union(DefineAdjective("coquine", "coquin", "coquines", "coquins"))
        ;

        public static IEnumerable<Adjective> DefineAdjective(
            string femSing, string mascSing, string femPlur, string mascPlur) {
            return new[] {
                new Adjective(femSing, Number.Singular, Gender.Feminin),
                new Adjective(mascSing, Number.Singular, Gender.Masculin),
                new Adjective(femPlur, Number.Plural, Gender.Feminin),
                new Adjective(mascPlur, Number.Plural, Gender.Masculin),
            };
        }

        public IEnumerable<string> GetAllWords() {
            return this.adjectives.Select(adjective => adjective.Text).Distinct();
        }

        public IEnumerable<IWordCategory> GetMatchingWords(Word word) {
            return this.adjectives.Where(adjective => adjective.Text == word.Value);
        }
    }
}
