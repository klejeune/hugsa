using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    class Preposition : IWordCategory {
        public string Text {
            get;
            set;
        }

        public Preposition(string text) {
            this.Text = text;
        }
        
        public WordCategoryType Type {
            get { return WordCategoryType.Preposition; }
        }
    }
}
