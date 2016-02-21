using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Dictionaries;
using Hugsa.Core.Engine.Statistics;

namespace Hugsa.Core.Engine {
    public class TextAnalyzer {
        public TextAnalysisReport AnalyzeText(string text) {
            var report = new TextAnalysisReport();

            report.AppendText(text);
            report.DictionaryAnalysisReport = new DictionaryAnalyzer().Analyze(report);
            report.StatisticalAnalysisReport = new StatisticalAnalyzer().Analyze(report);

            return report;
        }
    }
}
