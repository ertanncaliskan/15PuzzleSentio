using _15PuzzleLibrary.Heuristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary.Provider
{
    public static class HeuristicProvider
    {
        private static IHeuristic currentHeuristic { get; set; }
        public static void RegisterHeuristic(IHeuristic heuristic) {
            currentHeuristic = heuristic;
        }

        public static IHeuristic GetHeuristic() {
            return currentHeuristic ?? new DefaultHeuristic();
        }
    }
}
