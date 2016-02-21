using System;

namespace Hugsa.Core.Engine.WordTagging.WordCategories {
    class AdjectifPossessif : IWordCategory {
        public string Text {
            get; set;
        }

        public AdjectifPossessif(string text) {
            this.Text = text;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Determinant; }
        }
    }
}
