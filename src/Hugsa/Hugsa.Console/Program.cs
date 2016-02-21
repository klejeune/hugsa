using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core;
using Hugsa.Core.Data;
using Hugsa.Core.Engine;
using Hugsa.Core.Engine.SyntaxicAnalysis;

namespace Hugsa.Console {
    class Program {
        static void Main(string[] args) {
            var textAnalyzer = new TextAnalyzer();

            //var text = string.Join(" ", Texts.SimpleSentences.Take(20));
            var text = Texts.ComplexSentences.ElementAt(3);

            foreach (var sentence in new[] { text }) {
                var taggingReport = textAnalyzer.AnalyzeText(sentence);
                var sentenceReport = new SentenceAnalyzer().Analyze(taggingReport);

                System.Console.WriteLine(taggingReport.GetSummary());
                System.Console.WriteLine(sentenceReport.GetSummary());
                System.Console.WriteLine();
                System.Console.WriteLine();
            }
        }
    }
}
