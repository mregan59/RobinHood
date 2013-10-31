namespace RobinHoodGame
{
    partial class LevelBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelBase));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.balloonTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLbl = new System.Windows.Forms.Label();
            this.pointsLbl = new System.Windows.Forms.Label();
            this.arrowLbl = new System.Windows.Forms.Label();
            this.arrowCountLbl = new System.Windows.Forms.Label();
            this.resultLbl = new System.Windows.Forms.Label();
            this.balloonCrossingLbl = new System.Windows.Forms.Label();
            this.balloonCrossLbl = new System.Windows.Forms.Label();
            this.arrowSpeedTimer = new System.Windows.Forms.Timer(this.components);
            this.archer = new RobinHoodGame.GameObjects.Archer();
            ((System.ComponentModel.ISupportInitialize)(this.archer)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // balloonTimer
            // 
            this.balloonTimer.Enabled = true;
            this.balloonTimer.Interval = 2000;
            this.balloonTimer.Tick += new System.EventHandler(this.balloonTimer_Tick);
            // 
            // scoreLbl
            // 
            this.scoreLbl.AutoSize = true;
            this.scoreLbl.Location = new System.Drawing.Point(61, 333);
            this.scoreLbl.Name = "scoreLbl";
            this.scoreLbl.Size = new System.Drawing.Size(38, 13);
            this.scoreLbl.TabIndex = 2;
            this.scoreLbl.Text = "Score:";
            // 
            // pointsLbl
            // 
            this.pointsLbl.AutoSize = true;
            this.pointsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.pointsLbl.Location = new System.Drawing.Point(105, 318);
            this.pointsLbl.Name = "pointsLbl";
            this.pointsLbl.Size = new System.Drawing.Size(36, 39);
            this.pointsLbl.TabIndex = 3;
            this.pointsLbl.Text = "0";
            // 
            // arrowLbl
            // 
            this.arrowLbl.AutoSize = true;
            this.arrowLbl.Location = new System.Drawing.Point(4, 297);
            this.arrowLbl.Name = "arrowLbl";
            this.arrowLbl.Size = new System.Drawing.Size(95, 13);
            this.arrowLbl.TabIndex = 4;
            this.arrowLbl.Text = "Arrows Remaining:";
            // 
            // arrowCountLbl
            // 
            this.arrowCountLbl.AutoSize = true;
            this.arrowCountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.arrowCountLbl.Location = new System.Drawing.Point(101, 277);
            this.arrowCountLbl.Name = "arrowCountLbl";
            this.arrowCountLbl.Size = new System.Drawing.Size(55, 39);
            this.arrowCountLbl.TabIndex = 5;
            this.arrowCountLbl.Text = "20";
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F);
            this.resultLbl.Location = new System.Drawing.Point(218, 106);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(0, 108);
            this.resultLbl.TabIndex = 6;
            // 
            // balloonCrossingLbl
            // 
            this.balloonCrossingLbl.AutoSize = true;
            this.balloonCrossingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.balloonCrossingLbl.Location = new System.Drawing.Point(101, 238);
            this.balloonCrossingLbl.Name = "balloonCrossingLbl";
            this.balloonCrossingLbl.Size = new System.Drawing.Size(36, 39);
            this.balloonCrossingLbl.TabIndex = 7;
            this.balloonCrossingLbl.Text = "0";
            // 
            // balloonCrossLbl
            // 
            this.balloonCrossLbl.AutoSize = true;
            this.balloonCrossLbl.Location = new System.Drawing.Point(5, 258);
            this.balloonCrossLbl.Name = "balloonCrossLbl";
            this.balloonCrossLbl.Size = new System.Drawing.Size(90, 13);
            this.balloonCrossLbl.TabIndex = 8;
            this.balloonCrossLbl.Text = "Ballloons Crossed";
            // 
            // arrowSpeedTimer
            // 
            this.arrowSpeedTimer.Interval = 10000;
            this.arrowSpeedTimer.Tick += new System.EventHandler(this.arrowSpeedTimer_Tick);
            // 
            // archer
            // 
            this.archer.BackColor = System.Drawing.Color.Transparent;
            this.archer.Image = ((System.Drawing.Image)(resources.GetObject("archer.Image")));
            this.archer.Location = new System.Drawing.Point(16, 106);
            this.archer.Name = "archer";
            this.archer.size = new System.Drawing.Size(0, 0);
            this.archer.Size = new System.Drawing.Size(100, 95);
            this.archer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.archer.TabIndex = 0;
            this.archer.TabStop = false;
            // 
            // LevelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.balloonCrossLbl);
            this.Controls.Add(this.balloonCrossingLbl);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.arrowCountLbl);
            this.Controls.Add(this.arrowLbl);
            this.Controls.Add(this.pointsLbl);
            this.Controls.Add(this.scoreLbl);
            this.Controls.Add(this.archer);
            this.Name = "LevelBase";
            this.Size = new System.Drawing.Size(767, 418);
            ((System.ComponentModel.ISupportInitialize)(this.archer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RobinHoodGame.GameObjects.Archer archer;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer balloonTimer;
        private System.Windows.Forms.Label scoreLbl;
        private System.Windows.Forms.Label pointsLbl;
        private System.Windows.Forms.Label arrowLbl;
        private System.Windows.Forms.Label arrowCountLbl;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label balloonCrossingLbl;
        private System.Windows.Forms.Label balloonCrossLbl;
        private System.Windows.Forms.Timer arrowSpeedTimer;
    }
}
