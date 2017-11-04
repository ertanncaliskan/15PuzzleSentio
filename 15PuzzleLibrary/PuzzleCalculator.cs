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
        private static List<State> _possibleTree { get; set; }

        internal static State CalculatePuzzle(this State initialState) {
            _stateCodes = new List<string>();
            _possibleTree = new List<State>();
            var currentState = initialState;
            while (true)
            {
                if (currentState.ItemOrder.IsOrderedBy()) return currentState;
                var childState = currentState.FindChildState();
                if (childState == null) return null;
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
                ExtendPossibilityTree(currentChild);
            }
        }
        private static void ExtendPossibilityTree(State currentChild) {
            if (!_stateCodes.Contains(currentChild.StateCode) &&
                    _possibleTree.Where(x => x.StateCode == currentChild.StateCode && x.MovementCount < currentChild.MovementCount).FirstOrDefault() == null)
            {
                _possibleTree.Add(currentChild);
            }
        }
        private static State FindChildState(this State currentState) {
            State possibleChild = null;
            State currentChild = null;
            var pivot = currentState.PivotPoint;
            var currentRate = double.MaxValue;
            double calculatedRate = 0;
            var currentMatrix = currentState.ItemMatrix;
            foreach (var direction in currentState.PossibleDirections)
            {
                currentChild = currentState.PrepareState(pivot, new PivotPoint { X = direction.X, Y = direction.Y });
                DecidePossibleChild(ref possibleChild, currentChild, calculatedRate, ref currentRate);
            }
            possibleChild = ExtendDecisionWithFullTree(possibleChild);
            return possibleChild;
        }

        private static State ExtendDecisionWithFullTree(State possibleChild) {
            var minimumPossibles = _possibleTree.Where(x => !_stateCodes.Contains(x.StateCode)).OrderBy(p => p.StateRate).ToList();
            var minimumPossible = minimumPossibles.OrderBy(x => x.MovementCount).FirstOrDefault();
            if (possibleChild != null)
            {
                if (minimumPossible != null && minimumPossible.StateRate < possibleChild.StateRate) possibleChild = minimumPossible;
                _stateCodes.Add(possibleChild.StateCode);
            }
            else possibleChild = minimumPossible;
            return possibleChild;
        }

        private static State PrepareState(this State currentState, PivotPoint oldPoint, PivotPoint newPoint)
        {
            var newState = new State { PreviousState = currentState, ItemOrder = new List<long>() };
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
        internal static bool IsOrderedBy(this List<long> list)
        {
            int n = list.Count() - 1;
            var mustBeOrdered = list.TakeWhile((o, i) => i < n);
            var orderedByAsc = mustBeOrdered.OrderBy(d => d);
            if (mustBeOrdered.SequenceEqual(orderedByAsc) && !mustBeOrdered.Contains(0))
            {
                return true;
            }
            return false;
        }
    }
}
