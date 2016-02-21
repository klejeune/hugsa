using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Statistics;
using Parmenide.ConventionsCollectives.Core.Conflits.Engine;

namespace Hugsa.Core.Engine {
    public class TextAnalysisReport {
        public string Text { get; set; }
        public List<Sentence> Sentences = new List<Sentence>();

        public DictionaryAnalysisReport DictionaryAnalysisReport { get; set; }
        public StatisticalAnalysisReport StatisticalAnalysisReport { get; set; }

        public void AppendText(string text) {
            this.Sentences.AddRange(
                text.Split(new[] { ".", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(sentenceValue => !string.IsNullOrEmpty(sentenceValue.Trim('\n', '\r', ' ')))
                    .Select(sentenceValue => new Sentence(sentenceValue)).ToList());
        }

        public string GetSummary() {
            var builder = new StringBuilder();
            builder.AppendLine("---- Statistiques ----");
            builder.Append(this.StatisticalAnalysisReport.GetSummary());

            builder.AppendLine("---- Dictionaire ----");
            builder.AppendLine("Mots connus : " + this.DictionaryAnalysisReport.KnownWords.Count() +
                " (" + (this.DictionaryAnalysisReport.KnownWords.Count() * 100 / this.StatisticalAnalysisReport.WordCount) + "%)");
            builder.AppendLine("Mots inconnus : " + this.DictionaryAnalysisReport.UnknownWords.Count() +
                " (" + (this.DictionaryAnalysisReport.UnknownWords.Count() * 100 / this.StatisticalAnalysisReport.WordCount) + "%)");

            foreach (var word in this.DictionaryAnalysisReport.UnknownWords.Take(15)) {
                builder.AppendLine("- " + word.OriginalValue);
            }

            builder.AppendLine();

            foreach (var wordCategories in this.DictionaryAnalysisReport.WordCategories.Select((value, index) => new { value, index })) {
                builder.Append(wordCategories.index + " - " + wordCategories.value.Key);
                builder.AppendLine("    " + string.Join(", ", wordCategories.value.Value.Select(word => word.GetType().Name)));
            }


            return builder.ToString();
        }
    }
}
