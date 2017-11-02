using _15PuzzleLibrary.Heuristic;
using _15PuzzleLibrary.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary
{

    internal class PivotPoint {
        public long X { get; set; }
        public long Y { get; set; }
    }
    public class State
    {
        internal double StateRate { get { return HeuristicProvider.GetHeuristic().CalculateHeuristic(this); } set { } }
        public State PreviousState { get; internal set; }

        internal string StateCode { get { return String.Join(",", ItemOrder.ToArray()); } set { } }

        public List<long> ItemOrder { get; set; }
        
        internal long[][] ItemMatrix { get {
                var edgeLength = long.Parse(Math.Sqrt(ItemOrder.Count).ToString());
                var orderedMatrix = new long[edgeLength][];
                var index = 0;
                for (var i = edgeLength -1 ; i >= 0; i--)
                {
                    orderedMatrix[i] = new long[edgeLength];
                    for (var j = 0; j < edgeLength; j++)
                    {
                        orderedMatrix[i][j] = ItemOrder[index];
                        index++;
                    }
                }
                return orderedMatrix;
            } set { } }

        internal PivotPoint PivotPoint
        {
            get
            {
                var itemMatrix = ItemMatrix;
                var edgeLength = long.Parse(Math.Sqrt(ItemOrder.Count).ToString());
                for (var i = 0; i < edgeLength; i++)
                {
                    for (var j = 0; j < edgeLength; j++)
                        if (itemMatrix[i][j] == 0) return new PivotPoint { X=j, Y=i};
                }
                return null;
            }
            set { } }
    }
}
