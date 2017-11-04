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
        internal double StateRate { get { return HeuristicProvider.GetHeuristic().CalculateHeuristic(this); } }
        public State PreviousState { get; internal set; }

        internal string StateCode { get { return String.Join(",", ItemOrder.ToArray()); } }

        internal int MovementCount { get {
                var movementCount = 0;
                var currentState = this; while (currentState != null) {
                    movementCount++;
                    currentState = currentState.PreviousState;
                }
                return movementCount; } }

        public List<long> ItemOrder { get; internal set; }
        
        internal long[][] ItemMatrix { get {
                var orderedMatrix = new long[_edgeLength][];
                var index = 0;
                for (var i = _edgeLength - 1 ; i >= 0; i--)
                {
                    orderedMatrix[i] = new long[_edgeLength];
                    for (var j = 0; j < _edgeLength; j++)
                    {
                        orderedMatrix[i][j] = ItemOrder[index];
                        index++;
                    }
                }
                return orderedMatrix;
            } }
        private long _edgeLength { get { return long.Parse(Math.Sqrt(ItemOrder.Count).ToString()); } }
        internal PivotPoint PivotPoint
        {
            get
            {
                return PartPoint(0);
            }
        }

        internal List<PivotPoint> PossibleDirections { get {
                var directions = new List<PivotPoint>();
                var pivot = PivotPoint;
                if (pivot.X - 1 >= 0) directions.Add(new PivotPoint { X = pivot.X - 1, Y = pivot.Y });
                if (pivot.X + 1 < _edgeLength) directions.Add(new PivotPoint { X = pivot.X + 1, Y = pivot.Y });
                if (pivot.Y - 1 >= 0) directions.Add(new PivotPoint { X = pivot.X, Y = pivot.Y - 1 });
                if (pivot.Y + 1 < _edgeLength) directions.Add(new PivotPoint { X = pivot.X, Y = pivot.Y + 1 });
                return directions;
            }
        }
        internal PivotPoint PartPoint(long partIndex)
        {
            var itemMatrix = ItemMatrix;
            for (var i = 0; i < _edgeLength; i++)
            {
                for (var j = 0; j < _edgeLength; j++)
                    if (itemMatrix[i][j] == partIndex) return new PivotPoint { X = j, Y = i };
            }
            return null;
        }
    }
}
