using QuikGraph;

namespace Catan.Core
{
    class MapEdge : IEdge<MapVertex>
    {
        public MapVertex Source { get; }

        public MapVertex Target { get; }
    }
}
