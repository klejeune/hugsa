using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData {
    public interface ISemantics {
        IEnumerable<Word> Words { get; set; }
        bool IsUnknown { get; }
    }
}
