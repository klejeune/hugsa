using System.Collections.Generic;
using Hugsa.Core.Engine.WordTagging.WordCategories;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    class Subject : ISentencePart {
        public IEnumerable<Word> Words { get; private set; }

        public Subject(IEnumerable<Word> words) {
            this.Words = words;
        }
        
        public string Name {
            get { return "Subject"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return Cas.Nominatif; }
        }
    }
}
