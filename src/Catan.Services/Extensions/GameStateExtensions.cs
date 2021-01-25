using System;
using Catan.Core;
using Catan.Core.Constants;
using Catan.Core.Constants.Defaults;
using System.Collections.Generic;
using System.Linq;
using QuikGraph;
using QuikGraph.Algorithms;

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

            gameState.AdjacencyGraph.AddVerticesAndEdgeRange(edges);

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

        public static Tuple<Player, int> GetLongestRoad(this GameState gameState)
        {
            var playerWithLongestRoad = new Tuple<Player, int>(null, 0);

            foreach (Player player in gameState.Players)
            {
                var playerOwnedEdges = gameState.AdjacencyGraph.Edges.Where(edge => edge.PlayerOwner == player);

                var playerGraph = new UndirectedGraph<BoardVertex, BoardEdge>();
                playerGraph.AddVerticesAndEdgeRange(playerOwnedEdges);

                // Might need this for efficiency
                // var endpoints = playerGraph.Edges.Where(potentialEndpoint =>
                // {
                //     var sourceDegree = playerGraph.AdjacentDegree(potentialEndpoint.Source);
                //     var targetDegree = playerGraph.AdjacentDegree(potentialEndpoint.Target);

                //     return sourceDegree == 1 || targetDegree == 1;
                // });

                // var edgesToCheck = endpoints.Count() > 0 ? endpoints : playerGraph.Edges;

                var longestPath = 0;

                foreach (BoardEdge edge in playerGraph.Edges)
                {
                    var longestPathFromEndpoint = playerGraph.LongestPathDepthFirstSearch(player, edge);

                    if (longestPath < longestPathFromEndpoint)
                    {
                        longestPath = longestPathFromEndpoint;
                    }
                }

                if (longestPath >= 5 && (playerWithLongestRoad.Item1 == null || playerWithLongestRoad.Item2 < longestPath))
                {
                    playerWithLongestRoad = Tuple.Create(player, longestPath);
                }

            }

            return playerWithLongestRoad;
        }

        private static int LongestPathDepthFirstSearch(this UndirectedGraph<BoardVertex, BoardEdge> graph, Player player, BoardEdge edge)
        {
            var longestPath = 0;

            var visited = new HashSet<BoardEdge>();
            visited.Add(edge);

            var stack = new Stack<Tuple<BoardEdge, int>>();
            stack.Push(Tuple.Create(edge, 1));

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current.Item1))
                    continue;

                visited.Add(current.Item1);

                var vertices = new[] { current.Item1.Source, current.Item1.Target };

                foreach (BoardVertex vertex in vertices)
                {
                    if (vertex.PlayerOwner == player || vertex.Type == VertexTypeConstants.Empty)
                    {
                        foreach (BoardEdge neighbor in graph.AdjacentEdges(vertex).Where(edge => !visited.Contains(edge)))
                        {
                            visited.Add(neighbor);
                            stack.Push(Tuple.Create(neighbor, current.Item2 + 1));
                        }
                    }
                }

                if (longestPath < current.Item2)
                {
                    longestPath = current.Item2;
                }
            }

            return longestPath;
        }
    }
}