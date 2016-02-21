using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging.WordCategories.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis.SentenceParts {
    public interface ISentencePart {
        IEnumerable<Word> Words { get; }
        string Name { get; }
        Cas Cas { get; }
    }
}
