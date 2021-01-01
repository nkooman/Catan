using System.Collections.Generic;
using Catan.Core.Constants;

namespace Catan.Core
{
    public class BoardVertex
    {
        public VertexTypeConstants Type { get; set; }
        public Player PlayerOwner { get; set; }
        public Dictionary<ResourceConstants, int> Resources { get; set; }
        public IEnumerable<Hexagon> Hexagons { get; set; }
        public Harbor Harbor { get; set; }
    }
}
