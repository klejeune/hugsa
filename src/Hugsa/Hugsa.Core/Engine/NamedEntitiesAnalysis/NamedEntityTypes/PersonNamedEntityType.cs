using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.CandidateTypes;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes {
    class PersonNamedEntityType : AbstractNamedEntityType {
        public override NamedEntityManager.WordSemanticsAnalysisReport Analyze(Word word, NamedEntityManager.Context context) {
            var words = new[] {word, context.GetNextWord()};

            if (words.All(myWord => myWord != null && this.IsUpper(myWord))) {
                return new NamedEntityManager.WordSemanticsAnalysisReport {
                    Semantics = new NamedEntitySemantics {
                        NamedEntityType = this,
                        Words = words,
                    },
                    LeftWords = 0,
                    RightWords = 1,
                };
            }
            else {
                return null;
            }
        }

        private bool IsUpper(Word word) {
            return word.CandidateTypes.Any(candidate => candidate.GetType() == typeof(FirstUpperCandidateType));
        }
    }
}
