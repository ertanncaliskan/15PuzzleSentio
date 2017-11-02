using _15PuzzleLibrary;
using _15PuzzleLibrary.Heuristic;
using _15PuzzleLibrary.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15PuzzleSentio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<State> stateOrder { get; set; }
        private int stateIndex = 0;
        private State state = new State{ ItemOrder = new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 } };
        private void Form1_Load(object sender, EventArgs e)
        {
            HeuristicProvider.RegisterHeuristic(new ExtendedHeuristic());
            RenderState(state.ItemOrder);
        }        
        private void RenderState(List<long> order)
        {
            var ordered = new List<Control>();
            for (var i = 0; i < order.Count; i++)
            {
                var control = PuzzlePanel.Controls["button" + order[i]];
                ordered.Add(control);
            }
            foreach (var control in ordered) {
                PuzzlePanel.Controls.Remove(control);
            }

            foreach (var control in ordered)
            {
                PuzzlePanel.Controls.Add(control);
            }
        }
        private void extendedHeuristicBtn_Click(object sender, EventArgs e)
        {
            HeuristicProvider.RegisterHeuristic(new ExtendedHeuristic());

        }
        private void defaultHeuristicBtn_Click(object sender, EventArgs e)
        {
            HeuristicProvider.RegisterHeuristic(new DefaultHeuristic());

        }
        private void SolveBtn_Click(object sender, EventArgs e)
        {
            state = PuzzleCalculator.CalculatePuzzle(state);
            if (state == null) {
                MessageBox.Show("I couldn't find solution with this Heuristic :(");
                state = new State { ItemOrder = new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 } };
                return;
            }
            var currentState = state;
            stateOrder = new List<State>();
            while (currentState != null)
            {
                stateOrder.Insert(0, currentState);
                currentState = currentState.PreviousState;
            }
            NextStep.Text = "Netxt Step 0/" + stateOrder.Count;
            defaultHeuristicBtn.Visible = false;
            extendedHeuristicBtn.Visible = false;
            SolveBtn.Visible = false;
            NextStep.Visible = true;
        }

        private void NextStep_Click(object sender, EventArgs e)
        {
            RenderState(stateOrder.ElementAt(stateIndex).ItemOrder);
            stateIndex++;
            NextStep.Text = "Netxt Step "+ stateIndex + "/" + stateOrder.Count;
            if (stateIndex == stateOrder.Count)
                NextStep.Enabled = false;
        }
    }
}
