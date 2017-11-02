using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary
{
    public static class PuzzleCalculator
    {
        private static List<string> _stateCodes { get; set; }

        public static State CalculatePuzzle(this State initialState) {
            _stateCodes = new List<string>();
            var currentState = initialState;
            while (true)
            {
                if (currentState.ItemOrder.IsOrderedBy()) return currentState;
                var childState = currentState.FindChildState();
                if (childState == null) return null;
                childState.PreviousState = currentState;
                currentState = childState;
            }
        }
        private static void DecidePossibleChild(ref State possibleChild, State currentChild, double calculatedRate, ref double currentRate) {

            if (!_stateCodes.Contains(currentChild.StateCode))
            {
                calculatedRate = currentChild.StateRate;
                if (calculatedRate < currentRate)
                {
                    currentRate = calculatedRate;
                    possibleChild = currentChild;
                }
            }
        }
        private static State FindChildState(this State currentState) {
            State possibleChild = null;
            State currentChild = null;
            var pivot = currentState.PivotPoint;
            var currentRate = double.MaxValue;
            double calculatedRate = 0;
            var currentMatrix = currentState.ItemMatrix;
            if (pivot.X - 1 >= 0)
            {
                currentChild = currentState.PrepareState(pivot, new PivotPoint { X = pivot.X - 1, Y = pivot.Y });
                DecidePossibleChild(ref possibleChild, currentChild, calculatedRate, ref currentRate);
            }
            if (pivot.X+1 < currentState.ItemMatrix.GetLength(0))
            {
                currentChild = currentState.PrepareState(pivot, new PivotPoint { X = pivot.X + 1, Y = pivot.Y });
                DecidePossibleChild(ref possibleChild, currentChild, calculatedRate, ref currentRate);                
            }
            if (pivot.Y-1 >= 0)
            {
                currentChild = currentState.PrepareState(pivot, new PivotPoint { X = pivot.X, Y = pivot.Y - 1 });
                DecidePossibleChild(ref possibleChild, currentChild, calculatedRate, ref currentRate);
            }
            if (pivot.Y +1 < currentState.ItemMatrix.GetLength(0))
            {
                currentChild = currentState.PrepareState(pivot, new PivotPoint { X = pivot.X, Y = pivot.Y + 1 });
                DecidePossibleChild(ref possibleChild, currentChild, calculatedRate, ref currentRate);
            }
            
            if(possibleChild != null) _stateCodes.Add(possibleChild.StateCode);
            return possibleChild;
        }

        private static State PrepareState(this State currentState, PivotPoint oldPoint, PivotPoint newPoint)
        {
            var newState = new State { PivotPoint = newPoint, PreviousState = currentState, ItemOrder = new List<long>() };
            var itemMatrix = currentState.ItemMatrix;
            itemMatrix[oldPoint.Y][oldPoint.X] = itemMatrix[newPoint.Y][newPoint.X];
            itemMatrix[newPoint.Y][newPoint.X] = 0;

            var edgeLength = currentState.ItemMatrix.GetLength(0);

            for (var i = edgeLength - 1; i >= 0; i--)
            {
                for (var j = 0; j < edgeLength; j++)
                {
                    newState.ItemOrder.Add(itemMatrix[i][j]);
                }
            }

            return newState;
        }
        private static bool IsOrderedBy(this List<long> list)
        {
            int n = list.Count() - 1;
            var mustBeOrdered = list.TakeWhile((o, i) => i < n);
            var orderedByAsc = mustBeOrdered.OrderBy(d => d);
            if (mustBeOrdered.SequenceEqual(orderedByAsc))
            {
                return true;
            }
            return false;
        }

    }
}
