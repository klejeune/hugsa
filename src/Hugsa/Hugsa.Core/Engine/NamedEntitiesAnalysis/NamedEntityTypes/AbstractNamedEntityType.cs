using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes {
    public abstract class AbstractNamedEntityType {
        public abstract NamedEntityManager.WordSemanticsAnalysisReport Analyze(
            Word word, NamedEntityManager.Context context);
    }
}
