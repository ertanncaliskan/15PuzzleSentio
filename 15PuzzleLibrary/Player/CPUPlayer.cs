using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15PuzzleLibrary.Player
{
    public class CPUPlayer : PlayerBase
    {
        public CPUPlayer(List<long> order) : base(order)
        {
            var calculatedState = State.CalculatePuzzle();
            _orderedStatesForCPUPlayer = new List<State>();
            while (calculatedState != null)
            {
                _orderedStatesForCPUPlayer.Insert(0, calculatedState);
                calculatedState = calculatedState.PreviousState;
            }
            State = _orderedStatesForCPUPlayer.ElementAt(0);
        }
        private List<State> _orderedStatesForCPUPlayer { get; set; }
        public List<List<long>> OrdersStepByStep { get {
                return _orderedStatesForCPUPlayer.Select(x => x.ItemOrder).ToList();
            } }
        private int _renderedIndex = 0;
        public void PrepareNextState()
        {
            State = _orderedStatesForCPUPlayer.ElementAt(_renderedIndex);
            _renderedIndex++;
        }
    }
}
