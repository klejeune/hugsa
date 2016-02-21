using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine.SemanticsData;

namespace Parmenide.ConventionsCollectives.Core.Conflits.Engine {
    public class Sentence {
        public IEnumerable<Word> Words { get; set; }

        public List<ISemantics> Semantics { get; set; }

        public Sentence(string value) {
            this.Semantics = new List<ISemantics>();

            this.Words = value.Split(' ', '\'', ',', ':', '\"', '!')
                .Where(sentenceValue => !string.IsNullOrEmpty(sentenceValue.Trim('\n', '\r', ' ')))
                .Select(wordValue => new Word(wordValue))
                .ToList();
        }

        public override string ToString() {
            var builder = new StringBuilder();

            foreach (var word in this.Words.Select((value, index) => new {Value = value, Index = index})) {
                builder.Append("{ " + word.Index + " : " + word.Value + "} ");
            }

            return builder.ToString();
        }
    }
}
