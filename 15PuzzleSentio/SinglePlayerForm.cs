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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15PuzzleSentio
{
    public partial class SinglePlayerForm : PuzzleForm
    {
        public SinglePlayerForm()
        {
            HeuristicProvider.RegisterHeuristic(new ExtendedHeuristic());
            human = new HumanPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7, 11, 9, 12, 10, 15, 13, 14 });
            InitializeComponent();
        }
        private HumanPlayer human { get; set; }
        private void Resetbutton_Click(object sender, EventArgs e)
        {
            human = new HumanPlayer(new List<long> { 1, 3, 2, 5, 4, 8, 0, 6, 7, 11, 9, 12, 10, 15, 13, 14 });
            //I tried easy example for checking last step :P
            //human = new HumanPlayer(new List<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15 });
            RenderState(human.GetCurrentPuzzleOrder(), PlayerPanel, ButtonType.Human);
        }

        private void makeMovementForPlayer(object sender, EventArgs e)
        {
            if (!human.GameSucceeded())
            {
                human.PrepareNextState(FindPartNumber((Button)sender, ButtonType.Human));
                RenderState(human.GetCurrentPuzzleOrder(), PlayerPanel, ButtonType.Human);
            }
            if(human.GameSucceeded()) Humanlabel.Text = "PLAYER - I solved that Brotha!";
        }

        private void SinglePlayerForm_Load(object sender, EventArgs e)
        {
            Resetbutton.PerformClick();
        }
    }
}
