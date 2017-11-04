using _15PuzzleSentio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15PuzzleSentio
{
    public class PuzzleForm : Form
    {

        protected void RenderState(List<long> order, FlowLayoutPanel puzzlePanel, ButtonType buttonType)
        {
            var ordered = new List<Control>();
            for (var i = 0; i < order.Count; i++)
            {
                var control = puzzlePanel.Controls[buttonType + "button" + order[i]];
                ordered.Add(control);
            }
            foreach (var control in ordered)
            {
                puzzlePanel.Controls.Remove(control);
            }
            foreach (var control in ordered)
            {
                puzzlePanel.Controls.Add(control);
            }
        }

        protected long FindPartNumber(Button button, ButtonType buttonType) {
            return long.Parse(button.Name.Replace(buttonType + "button", ""));
        }

    }
}
