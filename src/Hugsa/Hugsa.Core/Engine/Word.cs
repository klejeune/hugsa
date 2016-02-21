using System.Collections.Generic;
using System.Linq;
using Hugsa.Core.Engine.CandidateTypes;
using Hugsa.Core.Engine.WordTagging;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.NamedEntityTypes;

namespace Hugsa.Core.Engine {
    public class Word {
        public string Value { get; set; }
        public string OriginalValue { get; set; }
        public IEnumerable<AbstractCandidateType> CandidateTypes { get; set; }
        public IEnumerable<IWordCategory> KnownMatchingCategories { get; set; }

        public bool MayBe(params WordCategoryType[] type) {
            return this.KnownMatchingCategories.Any(category => type.Contains(category.Type));
        }

        public Word(string value) {
            this.Value = value.ToLowerInvariant();
            this.OriginalValue = value;
        }

        public override string ToString() {
            return this.Value + " (" + string.Join(", ", this.CandidateTypes.Select(type => type.GetType().Name).ToArray()) + ")";
        }
    }
}
