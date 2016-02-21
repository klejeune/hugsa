using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.WordTagging;

namespace Hugsa.Core.Engine.Words {
    public interface IWordRepository {
        IEnumerable<string> GetAllWords();
        IEnumerable<IWordCategory> GetMatchingWords(Word word);
    }
}
