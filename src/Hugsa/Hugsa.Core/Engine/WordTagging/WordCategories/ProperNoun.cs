namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    internal class ProperNoun : IWordCategory {
        public string Text { get; set; }

        public ProperNoun(string text) {
            this.Text = text;
        }

        public WordCategoryType Type {
            get { return WordCategoryType.ProperNoun; }
        }
    }
}
