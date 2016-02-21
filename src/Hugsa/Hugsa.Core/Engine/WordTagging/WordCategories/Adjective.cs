using Hugsa.Core.Engine.Words.Attributes;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    public class Adjective : IWordCategory {
        public Adjective(string value, Number number, Gender gender) {
            this.Text = value;
            this.Number = number;
            this.Gender = gender;
        }

        public string Text { get; set; }
        public Number Number { get; set; }
        public Gender Gender { get; set; }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Adjective; }
        }
    }
}
