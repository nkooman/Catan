using QuikGraph;
using System.Collections.Generic;

namespace Catan.Core
{
    public class GameState
    {
        public BidirectionalGraph<BoardVertex, BoardEdge> MapAdjacencyGraph { get; set; }
        public IEnumerable<Hexagon> Hexagons { get; set; }
        public IEnumerable<Harbor> Harbors { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
