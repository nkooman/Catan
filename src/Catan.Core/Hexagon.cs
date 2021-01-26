using HexagonalLib;
using System.Collections.Generic;
using Catan.Core.Constants;

namespace Catan.Core
{
    public class Hexagon
    {
        public HexagonalLib.Coordinates.Cubic Position { get; set; }
        public ResourceConstants Resource { get; set; }
        public int RollNumber { get; set; }
        public IEnumerable<BoardVertex> Vertices { get; set; }
        public bool HasRobber { get; set; }
    }
}