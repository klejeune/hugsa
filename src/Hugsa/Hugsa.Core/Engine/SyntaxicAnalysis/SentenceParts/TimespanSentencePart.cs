using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    class TimespanSentencePart : ISentencePart {
          public IEnumerable<Word> Words {
            get; private set;
        }

          public TimespanSentencePart(IEnumerable<Word> words) {
            this.Words = words;
        }

        public string Name {
            get {return "TimeSpan"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return WordTagging.WordCategories.Attributes.Cas.Oblique; }
        }
    }
}
