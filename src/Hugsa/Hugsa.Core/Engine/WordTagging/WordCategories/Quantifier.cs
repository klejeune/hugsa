namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class Quantifier : IWordCategory {
        public string Text { get; set; }

        public Quantifier(string text) {
            this.Text = text;
        }

        public WordCategoryType Type {
            get { return WordCategoryType.Quantifier; }
        }
    }
}
