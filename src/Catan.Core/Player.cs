using System.Collections.Generic;
using Catan.Core.Constants;

namespace Catan.Core
{
    public class Player
    {
        public string Name { get; set; }
        public Dictionary<ResourceConstants, int> Resources { get; set; }
        public Dictionary<StructureConstants, int> Structres { get; set; }
    }
}
