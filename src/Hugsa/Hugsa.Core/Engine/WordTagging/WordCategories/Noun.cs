using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    public class Noun : IWordCategory {
        public Noun(string value, Number number, Gender gender) {
            this.Text = value;
            this.Number = number;
            this.Gender = gender;
        }

        public string Text { get; set; }
        public Number Number { get; set; }
        public Gender Gender { get; set; }


        public WordCategoryType Type {
            get {
                return WordCategoryType.Noun;
            }
        }
    }
}
