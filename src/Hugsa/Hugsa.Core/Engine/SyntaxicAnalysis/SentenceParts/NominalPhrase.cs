using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    class NominalPhrase : ISentencePart {
        public IEnumerable<Word> Words {
            get;
            private set;
        }

        public Word Determinant { get; private set; }
        public Word Noun { get; private set; }
        public IEnumerable<Word> Adjectives { get; private set; }

        public NominalPhrase(Word determinant, Word noun, IEnumerable<Word> adjectives) {
            this.Determinant = determinant;
            this.Noun = noun;
            this.Adjectives = adjectives.ToList();
            this.Words = new[] { determinant, noun }.Concat(this.Adjectives);
        }

        public string Name {
            get { return "GroupeNominal"; }
        }

        public WordTagging.WordCategories.Attributes.Cas Cas {
            get { return Cas.Undefined; }
        }
    }
}
