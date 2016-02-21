using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes {
    public class OrganisationNamedEntityType : AbstractNamedEntityType {
        public override NamedEntityManager.WordSemanticsAnalysisReport Analyze(Word word, NamedEntityManager.Context context) {
            if (word.Value == "SNCM") {
                return new NamedEntityManager.WordSemanticsAnalysisReport {
                    Semantics = new NamedEntitySemantics {
                        NamedEntityType = this,
                        Words = new[] { word }
                    },
                };
            }
            else {
                return null;
            }
        }
    }
}
