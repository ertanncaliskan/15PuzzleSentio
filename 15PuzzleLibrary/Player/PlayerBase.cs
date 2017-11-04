using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary.Player
{
    public abstract class PlayerBase
    {
        public PlayerBase(List<long> order) {
            State = new State { ItemOrder = order };
        }

        protected State State { get; set; }

        public List<long> GetCurrentPuzzleOrder() {
            return State.ItemOrder;
        }
        public bool GameSucceeded () {
            return State.ItemOrder.IsOrderedBy();
        }
    }
}
