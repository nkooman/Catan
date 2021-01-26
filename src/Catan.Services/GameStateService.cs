using HexagonalLib;
using QuikGraph;
using Catan.Core;
using Catan.Services.Abstractions;

namespace Catan.Services
{
    public class GameStateService : IGameStateService
    {
        private GameState gameState;

        public GameStateService()
        {
            this.gameState = new GameState();
        }

        public GameState InitializeGameState()
            => new GameState()
            {
                AdjacencyGraph = new UndirectedGraph<BoardVertex, BoardEdge>(),
                Grid = new HexagonalGrid(HexagonalGridType.PointyEven, 1.0f),
                Hexagons = new Hexagon[] { },
                Harbors = new Harbor[] { },
                Players = new Player[] { },
            };
    }
}