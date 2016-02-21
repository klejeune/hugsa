using System.Linq;

namespace Hugsa.Core.Engine.Statistics {
    public class StatisticalAnalyzer {
        public StatisticalAnalysisReport Analyze(TextAnalysisReport report) {
            return new StatisticalAnalysisReport {
                SentenceCount = report.Sentences.Count,
                WordCount = report.Sentences.Sum(sentence => sentence.Words.Count())
            };
        }
    }
}
