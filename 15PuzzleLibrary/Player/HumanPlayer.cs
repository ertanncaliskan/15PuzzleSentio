using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary.Player
{
    public class HumanPlayer : PlayerBase
    {
        public HumanPlayer(List<long> order) : base(order)
        {
        }

        public void PrepareNextState(long partIndex)
        {
            var pivot = State.PivotPoint;
            var partPoint = State.PartPoint(partIndex);
            var currentOrder = State.ItemOrder;
            if (partPoint.X - 1 == pivot.X && partPoint.Y == pivot.Y ||
                partPoint.X + 1 == pivot.X && partPoint.Y == pivot.Y ||
                partPoint.X == pivot.X && partPoint.Y - 1 == pivot.Y ||
                partPoint.X == pivot.X && partPoint.Y + 1 == pivot.Y)
            {
                var partOrder = currentOrder.FindIndex(a => a == partIndex);
                var pivotOrder = currentOrder.FindIndex(a => a == 0);
                var tmp = currentOrder[partOrder];
                currentOrder[partOrder] = currentOrder[pivotOrder];
                currentOrder[pivotOrder] = tmp;
                var state = new State { ItemOrder = currentOrder };
                state.PreviousState = State;
                State = state;
            }
        }
    }
}
