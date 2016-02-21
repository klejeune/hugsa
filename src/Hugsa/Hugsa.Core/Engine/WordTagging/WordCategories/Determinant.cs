using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.SyntaxAnalysis.Words.WordCategories {
    public class Determinant : IWordCategory {
        public string Text { get; set; }
        public bool IsDefini { get; set; }
        public Gender Gender { get; set; }
        public Number Number { get; set; }

        public Determinant(string text, bool isDefini, Gender gender, Number number) {
            this.Text = text;
            this.IsDefini = isDefini;
            this.Gender = gender;
            this.Number = number;
        }

        public WordCategoryType Type {
            get {
                return WordCategoryType.Determinant;
            }
        }
    }
}
