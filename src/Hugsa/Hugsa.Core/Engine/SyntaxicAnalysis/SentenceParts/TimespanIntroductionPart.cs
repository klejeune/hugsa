using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    class TimespanIntroductionPart : ISentencePart {
        public IEnumerable<Word> Words {
            get; private set;
        }

        public TimespanIntroductionPart(IEnumerable<Word> words) {
            this.Words = words;
        }

        public string Name {
            get {return "TimeSpanIntroduction"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return Cas.Oblique; }
        }
    }
}
