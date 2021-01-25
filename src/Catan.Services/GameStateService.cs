using Catan.Core;
using Catan.Services.Abstractions;
using QuikGraph;

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
                Hexagons = new Hexagon[] { },
                Harbors = new Harbor[] { },
                Players = new Player[] { },
            };
    }
}