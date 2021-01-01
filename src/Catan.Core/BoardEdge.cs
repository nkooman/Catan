using System.Diagnostics.CodeAnalysis;
using Catan.Core.Constants;
using QuikGraph;

namespace Catan.Core
{
    public class BoardEdge : Edge<BoardVertex>
    {
        public BoardEdge([NotNullAttribute] BoardVertex source, [NotNullAttribute] BoardVertex target)
            : base(source, target) { }

        public EdgeTypeConstants Type { get; set; }
        public Player PlayerOwner { get; set; }
    }
}
