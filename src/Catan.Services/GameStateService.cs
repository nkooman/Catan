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
                Harbors = new Harbor[] { },
                Hexagons = new Hexagon[] { },
                Players = new Player[] { },
                MapAdjacencyGraph = new BidirectionalGraph<BoardVertex, BoardEdge>(false, 9999, 3),
            };
    }
}