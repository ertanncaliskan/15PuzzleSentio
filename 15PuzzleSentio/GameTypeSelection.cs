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
    public partial class GameTypeSelection : Form
    {
        public GameTypeSelection()
        {
            InitializeComponent();
        }
        PuzzleForm Form { get; set; }
        private void Singlebutton_Click(object sender, EventArgs e)
        {
            if (Form != null) Form.Close();
            Form = new SinglePlayerForm();
            Form.Show();
        }

        private void CPUbutton_Click(object sender, EventArgs e)
        {
            if (Form != null) Form.Close();
            Form = new VSBotForm();
            Form.Show();
        }
    }
}
