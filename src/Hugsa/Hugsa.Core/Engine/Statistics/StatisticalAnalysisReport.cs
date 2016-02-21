using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugsa.Core.Engine.Statistics {
    public class StatisticalAnalysisReport {
        public int WordCount { get; set; }
        public int SentenceCount { get; set; }

        public string GetSummary() {
            return "Phrases : " + this.SentenceCount + "\n" +
                   "Mots : " + this.WordCount + "\n";
        }
    }
}
