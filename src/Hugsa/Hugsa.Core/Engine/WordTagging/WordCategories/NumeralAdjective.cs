using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words.Attributes;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    class NumeralAdjective : IWordCategory {
        public string Text { get; set; }
        public Gender Gender { get; set; }

        public NumeralAdjective(string text, Gender gender) {
            this.Text = text;
            this.Gender = gender;
        }

        public WordCategoryType Type {
            get { return WordCategoryType.Determinant; }
        }
    }
}
