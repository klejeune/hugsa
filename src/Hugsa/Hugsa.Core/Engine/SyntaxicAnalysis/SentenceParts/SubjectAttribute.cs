using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    class SubjectAttribute : ISentencePart {
        public IEnumerable<Word> Words {
            get; private set;
        }

        public string Name {
            get { return "Attribut du sujet"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return Cas.Nominatif; }
        }

        public SubjectAttribute(IEnumerable<Word> words) {
            this.Words = words;
        }
    }
}
