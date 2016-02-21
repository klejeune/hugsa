using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Dictionaries {
    public class DictionaryAnalysisReport {
        public IEnumerable<Word> UnknownWords { get; set; }
        public IEnumerable<Word> KnownWords { get; set; }
        public IEnumerable<KeyValuePair<string, IEnumerable<IWordCategory>>> WordCategories { get; set; }
    }
}
