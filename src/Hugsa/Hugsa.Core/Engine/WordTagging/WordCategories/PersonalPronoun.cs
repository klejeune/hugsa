using Hugsa.Core.Engine.Words;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class PersonalPronoun : IWordCategory {
        public string Text {get; set;}
        public Person Person { get; set; }
        public Cas Cas { get; set; }
        public Gender Gender { get; set; }
        public Number Number { get; set; }

        public PersonalPronoun(string text, Person person, Cas cas, Gender gender, Number number) {
            this.Text = text;
            this.Person = person;
            this.Cas = cas;
            this.Gender = gender;
            this.Number = number;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Pronoun; }
        }
    }
}
