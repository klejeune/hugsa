using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData {
    class NamedEntitySemantics : ISemantics {
        public AbstractNamedEntityType NamedEntityType { get; set; }
        public IEnumerable<Word> Words { get; set; }


        public bool IsUnknown {
            get { return false; }
        }

        public override string ToString() {
            return this.NamedEntityType.GetType().Name + " : " + string.Join(" ", Words.Select(word => word.Value).ToArray());
        }
    }
}
