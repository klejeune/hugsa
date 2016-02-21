namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class RelativePronoun : IWordCategory {
        public string Text {get; set;}

        public RelativePronoun(string text) {
            this.Text = text;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Conjunction; }
        }
    }
}
