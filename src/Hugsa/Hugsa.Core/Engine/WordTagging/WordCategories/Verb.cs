using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    class Verb : IWordCategory {
        public string Text { get; set; }
        public Person Person { get; set; }
        public Temps Temps { get; set; }
        public Number Number { get; set; }
        public string VerbId { get; set; }

        public Verb(string text, string verbId, Person person, Number number, Temps temps) {
            this.Text = text;
            this.VerbId = verbId;
            this.Person = person;
            this.Number = number;
            this.Temps = temps;
        }

        public override string ToString() {
            return this.Text + " (Verb)";
        }


        public WordCategoryType Type {
            get {return WordCategoryType.Verb; }
        }
    }

    public enum Person {
        Undefined,
        First,
        Second,
        Third,
        Infinitive,
        ParticipePresent,
    }

    public enum Temps {
        Undefined,
        Present,
        Imparfait,
        PasseSimple,
        FuturSimple,
    }
}
