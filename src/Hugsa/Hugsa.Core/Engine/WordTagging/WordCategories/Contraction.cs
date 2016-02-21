using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    class Contraction : IWordCategory {
        public string Text {get; set;}
        public IEnumerable<IWordCategory> Replacement { get; set; }
        public bool IsCompulsory { get; set; }

        public Contraction(string text, IEnumerable<IWordCategory> replacement, bool isCompulsory) {
            this.Text = text;
            this.Replacement = replacement;
            this.IsCompulsory = isCompulsory;
        }
        
        public WordCategoryType Type {
            get { throw new NotImplementedException(); }
        }
    }
}
