namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class Negation : IWordCategory {
        public string Text { get; set; }

        public Negation(string text) {
            this.Text = text;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Negation; }
        }
    }
}
