using System;
using Catan.Core.Constants;

namespace Catan.Core
{
    public class Harbor
    {
        public ResourceConstants Cost { get; set; }
        public ResourceConstants Offer { get; set; }
        public Tuple<int, int> ExchangeRate { get; set; }
        public BoardVertex Vertex { get; set; }
    }
}