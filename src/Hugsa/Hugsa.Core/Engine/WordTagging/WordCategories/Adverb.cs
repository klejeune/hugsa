using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class Adverb : IWordCategory {
        public string Text { get; set; }
        public AdverbType AdverbType { get; set; }

        public Adverb(string text, AdverbType type) {
            this.Text = text;
            this.AdverbType = type;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Adverb; }
        }
    }
}
