using _15PuzzleLibrary.Heuristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15PuzzleLibrary;

namespace _15PuzzleSentio
{
    public class ExtendedHeuristic : IHeuristic
    {
        public double CalculateHeuristic(State state)
        {
            double cost = 0;
            for (var i = 0; i < state.ItemOrder.Count; i++)
            {
                if (state.ItemOrder[i] == 0) cost += (state.ItemOrder.Count - (i + 1));
                double val = (i + 1 - state.ItemOrder[i]);
                cost += (val < 0 ? val * -1 : val);
            }
            return cost;
        }
    }
}
