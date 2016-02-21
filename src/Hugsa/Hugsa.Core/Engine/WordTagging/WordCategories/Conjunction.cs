using Hugsa.Core.Engine.Words.Attributes;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class Conjunction : IWordCategory {        
        public string Text {get; set;}
        public ConjunctionType ConjunctionType { get; set; }

        public Conjunction(string text, ConjunctionType conjunctionType) {
            this.Text = text;
            this.ConjunctionType = conjunctionType;
        }

        public WordCategoryType Type {
            get { return WordCategoryType.Conjunction; }
        }
    }
}
