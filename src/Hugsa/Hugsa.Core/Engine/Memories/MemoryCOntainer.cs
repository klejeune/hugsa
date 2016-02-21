using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hugsa.Core.Engine.SyntaxicAnalysis;

namespace Hugsa.Core.Engine.Memories {
    class MemoryContainer {
        private static MemoryContainer instance;

        public static MemoryContainer Instance {
            get {
                if (instance == null) {
                    instance = new MemoryContainer();
                }

                return instance;
            }
        }

        private MemoryContainer() { }

        private readonly IDictionary<string, EntityInformation> entities = new Dictionary<string, EntityInformation>();

        public IEnumerable<EntityInformation> Entities { get { return this.entities.Values; } }

        public EntityInformation GetEntityByName(string name) {
            EntityInformation thisEntity = null;

            if (!this.entities.TryGetValue(name, out thisEntity)) {
                thisEntity = new EntityInformation();

                thisEntity.AddAttribute("s'appelle " + name);

                this.entities.Add(name, thisEntity);
            }

            return thisEntity;
        }
    }
}
