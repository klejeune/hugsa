using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Hugsa.Core.Engine.CandidateTypes;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes {
    class SigleCandidateType : AbstractCandidateType {
        public override bool IsCandidate(Word word) {
            return word.Value.All(char.IsUpper);
        }
    }
}
