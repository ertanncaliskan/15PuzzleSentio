namespace _15PuzzleSentio
{
    partial class GameTypeSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Singlebutton = new System.Windows.Forms.Button();
            this.CPUbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Singlebutton
            // 
            this.Singlebutton.Location = new System.Drawing.Point(12, 12);
            this.Singlebutton.Name = "Singlebutton";
            this.Singlebutton.Size = new System.Drawing.Size(166, 82);
            this.Singlebutton.TabIndex = 0;
            this.Singlebutton.Text = "Single Player";
            this.Singlebutton.UseVisualStyleBackColor = true;
            this.Singlebutton.Click += new System.EventHandler(this.Singlebutton_Click);
            // 
            // CPUbutton
            // 
            this.CPUbutton.Location = new System.Drawing.Point(184, 12);
            this.CPUbutton.Name = "CPUbutton";
            this.CPUbutton.Size = new System.Drawing.Size(166, 82);
            this.CPUbutton.TabIndex = 2;
            this.CPUbutton.Text = "VS CPU";
            this.CPUbutton.UseVisualStyleBackColor = true;
            this.CPUbutton.Click += new System.EventHandler(this.CPUbutton_Click);
            // 
            // GameTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 106);
            this.Controls.Add(this.CPUbutton);
            this.Controls.Add(this.Singlebutton);
            this.Name = "GameTypeSelection";
            this.Text = "Select Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Singlebutton;
        private System.Windows.Forms.Button CPUbutton;
    }
}