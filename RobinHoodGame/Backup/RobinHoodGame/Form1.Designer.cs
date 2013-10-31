namespace RobinHoodGame
{
    partial class Form1
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
            this.levelBase1 = new RobinHoodGame.LevelBase();
            this.SuspendLayout();
            // 
            // levelBase1
            // 
            this.levelBase1.BackColor = System.Drawing.Color.White;
            this.levelBase1.Location = new System.Drawing.Point(21, 12);
            this.levelBase1.Name = "levelBase1";
            this.levelBase1.Size = new System.Drawing.Size(837, 454);
            this.levelBase1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 497);
            this.Controls.Add(this.levelBase1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LevelBase levelBase1;
    }
}

