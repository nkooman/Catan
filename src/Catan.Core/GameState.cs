using HexagonalLib;
using QuikGraph;
using System.Collections.Generic;

namespace Catan.Core
{
    public class GameState
    {
        public UndirectedGraph<BoardVertex, BoardEdge> AdjacencyGraph { get; set; }
        public HexagonalGrid Grid { get; set; }
        public IEnumerable<Hexagon> Hexagons { get; set; }
        public IEnumerable<Harbor> Harbors { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
