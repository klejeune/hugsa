using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    public class VerbPart : ISentencePart {
        public Word Verb { get; private set; }

        public VerbPart(Word verb) {
            this.Verb = verb;
        }

        public IEnumerable<Word> Words {
            get { return new[] { this.Verb }; }
        }

        public string Name {
            get { return "Verb"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return Cas.Verbe; }
        }
    }
}
