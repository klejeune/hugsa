using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData {
    class UnknownWordSemantics : ISemantics {
        public UnknownWordSemantics(Word word)
        {
            this.Words = new[] {word};
        }

        public IEnumerable<Word> Words {
            get; set;
        }
        
        public bool IsUnknown {
            get { return true; }
        }
    }
}
