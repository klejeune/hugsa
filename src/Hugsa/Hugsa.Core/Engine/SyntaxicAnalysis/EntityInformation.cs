using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.Words.Attributes;

namespace Hugsa.Core.Engine.SyntaxicAnalysis {
    public class EntityInformation {
        private readonly List<string> attributes = new List<string>();

        public IEnumerable<string> Attributes { get { return this.attributes; } }

        public Gender Gender { get; set; }
        public Number Number { get; set; }

        public void AddAttribute(string attribute) {
            this.attributes.Add(attribute);
        }
    }
}
