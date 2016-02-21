using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class SentenceContext : IContext<Word> {
        public VerbPart Verb { get; set; }
    }
}
