using _15PuzzleLibrary;
using _15PuzzleLibrary.Heuristic;
using _15PuzzleLibrary.Player;
using _15PuzzleLibrary.Provider;
using _15PuzzleSentio.Enum;
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
    
    public partial class VSBotForm : PuzzleForm
    {
        private HumanPlayer human { get; set; } 
        private CPUPlayer cpu { get; set; } 
        public VSBotForm()
        {
            HeuristicProvider.RegisterHeuristic(new ExtendedHeuristic());
            human = new HumanPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 });
            cpu = new CPUPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 });
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RenderState(cpu.GetCurrentPuzzleOrder(), PuzzlePanel, ButtonType.CPU);
            RenderState(human.GetCurrentPuzzleOrder(), PlayerPanel, ButtonType.Human);
            HeuristicProvider.RegisterHeuristic(new ExtendedHeuristic());
        }        
        protected void makeMovementForPlayer(object sender, EventArgs e)
        {
            if (!human.GameSucceeded()) {
                if (!cpu.GameSucceeded()) {
                    cpu.PrepareNextState();
                    RenderState(cpu.GetCurrentPuzzleOrder(), PuzzlePanel, ButtonType.CPU);
                }
                else CPUlabel.Text = "CPU - I solved that Brotha!";
                human.PrepareNextState(FindPartNumber((Button)sender, ButtonType.Human));
                RenderState(human.GetCurrentPuzzleOrder(), PlayerPanel, ButtonType.Human);
            }
            if (human.GameSucceeded()) Humanlabel.Text = "PLAYER - I solved that Brotha!";
        }

        private void Resetbutton_Click(object sender, EventArgs e)
        {
            human = new HumanPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 });
            cpu = new CPUPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7 });
            RenderState(cpu.GetCurrentPuzzleOrder(), PuzzlePanel, ButtonType.CPU);
            RenderState(human.GetCurrentPuzzleOrder(), PlayerPanel, ButtonType.Human);
        }
    }
}
