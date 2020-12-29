using QuikGraph;
using System.Collections.Generic;

namespace Catan.Core
{
    class GameState
    {
        public AdjacencyGraph<MapVertex, MapEdge> MapAdjacencyGraph { get; set; }
        public Dictionary<string, Player> Players { get; set; }
    }
}
