using Catan.Core;
using Catan.Core.Constants;
using Catan.Core.Constants.Defaults;
using System.Collections.Generic;
using System.Linq;

namespace Catan.Services.Extensions
{
    public static class GameStateExtensions
    {
        public static GameState CreateDefaultGameState(this GameState gameState)
        {
            var vertices = Enumerable.Range(1, 6).Select(x => new BoardVertex()
            {
                PlayerOwner = new Player(),
                Resources = new Dictionary<ResourceConstants, int>(),
                Type = VertexTypeConstants.Empty
            }).ToList();

            var edges = Enumerable.Range(1, 6).Select(x =>
            {
                BoardVertex source = vertices.ElementAt(x - 1);
                BoardVertex target = vertices.ElementAt(x < 6 ? x : 0);

                return new BoardEdge(source, target);
            }).ToList();

            gameState.MapAdjacencyGraph.AddVerticesAndEdgeRange(edges);

            var hexagon = new Hexagon()
            {
                HasRobber = false,
                Resource = ResourceConstants.Brick,
                RollNumber = 7,
                Vertices = vertices
            };

            gameState.Hexagons = gameState.Hexagons.Append(hexagon);

            return gameState;
        }

        public static GameState SetDefaultPlayerStructures(this GameState gameState)
        {
            gameState.Players.Select(player =>
                player.Structures.Select(structure =>
                    DefaultPlayerStructureConstants.Structures[structure.Key]));

            return gameState;
        }
    }
}