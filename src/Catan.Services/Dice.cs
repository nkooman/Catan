using System.Linq;
using System.Collections.Generic;
using System;

namespace Catan.Services
{
    public class Dice
    {
        private Random Die = new Random();

        // Upper bound is exclusive; therefore for a six-sided die we use 7 instead.
        public int RollDie() => Die.Next(1, 7);
        public IEnumerable<int> RollDice(int count)
            => Enumerable.Range(1, count).Select(x => RollDie());
    }
}