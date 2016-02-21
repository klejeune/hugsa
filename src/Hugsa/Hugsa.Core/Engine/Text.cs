using System;
using System.Collections.Generic;
using System.Linq;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine;

namespace Hugsa.Core.Engine {
    public class Text {
        public IEnumerable<Sentence> Sentences { get; set; }

        public Text(string value) {
            throw new InvalidOperationException();

            this.Sentences = value.Split(new[] { "...", ". ", " .", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(sentenceValue => !string.IsNullOrEmpty(sentenceValue.Trim('\n', '\r', ' ')))
                .Select(sentenceValue => new Sentence(sentenceValue)).ToList();
        }
    }
}
