using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary.Heuristic
{
    public class DefaultHeuristic : IHeuristic
    {
        public double CalculateHeuristic(State state)
        {
            var cost = 0;
            for (var i = 0; i < state.ItemOrder.Count; i++)
            {
                if (state.ItemOrder[i] == 0 && i != state.ItemOrder.Count-1) cost++;
                if (state.ItemOrder[i] != i + 1) cost++;
            }
            return cost;
        }
    }
}
