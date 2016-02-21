using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class SentenceAnalysisReport {
        public IEnumerable<IEnumerable<ISentencePart>> SentenceParts { get; set; }
        public string ErrorMessage { get; set; }

        public string GetSummary() {
            var builder = new StringBuilder();

            builder.AppendLine("---- Sentence analysis ----");

            if (this.SentenceParts != null && this.SentenceParts.Any()) {
                foreach (var sentence in this.SentenceParts) {
                    builder.AppendLine(
                        "Phrase : "
                        + string.Join(
                            " ",
                            sentence.Select(
                                part =>
                                    part.Name + "("
                                    + string.Join(
                                        " ", part.Words.Where(word => word != null).Select(word => word.OriginalValue))
                                    + ")")));
                }
            }
            else {
                builder.AppendLine(ErrorMessage);
            }

            return builder.ToString();
        }
    }
}
