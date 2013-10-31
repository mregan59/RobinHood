using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobinHoodGame.GameObjects;
using RobinHoodGame.Properties;

namespace RobinHoodGame
{
    public partial class LevelBase : UserControl
    {
        private int arrowCount = 20;
        
        private Arrow arrow;
        private Balloon balloon;
        private Random random = new Random();
        private List<Arrow> arrows = new List<Arrow>();
        private List<Balloon> balloons;
        private List<Balloon> balloonsToRemove = new List<Balloon>();
        //private List<Balloon> scoreBalloons = new List<Balloon>();
        private string gameState;


        private BalloonManager balloonManager;
        private int archerSpeed = 7;
        private int arrowSpeed = 8;
        int balloonCount = 0;

        public LevelBase()
        {
            InitializeComponent();
            gameState = "Running";
            balloonManager = new BalloonManager(this);
            PreviewKeyDown += new PreviewKeyDownEventHandler(LevelBase_PreviewKeyDown);
        }

        void LevelBase_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                archer.OffSet(0, -archerSpeed);
            }
            else if (e.KeyCode == Keys.Down)
            { 
                archer.OffSet(0, archerSpeed);
            }
            else if (e.KeyCode == Keys.Left)
            {
                archer.OffSet(-archerSpeed, 0);
            }
            else if(e.KeyCode == Keys.Right)
            {
                archer.OffSet(archerSpeed, 0);
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (gameState == "Running" || gameState == "Shooting")
                {
                    Shoot();
                    gameState = "Shooting";
                }
            }
        }

        public void ArcherWallCollision()
        {
            if (archer.Right >= 300)
            {
                archer.Location = new Point(300 - archer.Width, archer.Location.Y);
            }
            if (archer.Left <= this.Left)
            {
                archer.Location = new Point(this.Left, archer.Location.Y);
            }
            if (archer.Top <= this.Top)
            {
                archer.Location = new Point(archer.Location.X, this.Top);
            }
            if (archer.Bottom >= this.Bottom)
            {
                archer.Location = new Point(archer.Location.X, this.Bottom - archer.Height);
            }
        }

        public void ArrowBalloonCollision()
        {
            foreach (Arrow arrow in arrows)
            {
                foreach (Balloon balloon in balloons)
                {
                    if (arrow.Bounds.IntersectsWith(balloon.Bounds))
                    {
                        balloon.Image = Resources.balloonPop;
                        CheckBalloonColor(balloon);
                    }
                }
            }
        }

        public void HandleArrowVelocity()
        {
            
            foreach(Arrow arrow in arrows)
            {
                if (arrow.Left <= this.Right)
                {
                    arrow.OffSet(arrowSpeed, 0);
                }
                else if (arrow.Left >= this.Right)
                {
                    this.Controls.Remove(arrow);
                }
            }
        }
        public void Shoot()
        {
            if (arrows.Count < arrowCount)
            {
                arrow = new Arrow();
                arrows.Add(arrow);
                arrow.Location = new Point(archer.Location.X, archer.Location.Y + 7);
                this.Controls.Add(arrow);
                arrowCountLbl.Text = (int.Parse(arrowCountLbl.Text) - 1).ToString();
            }
        }
        
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ArcherWallCollision();
            if (gameState == "Shooting"|| gameState == "Game Over")
            {
                HandleArrowVelocity();
            }
            balloonManager.HandleBalloonSpeed();
            ArrowBalloonCollision();
            BalloonCrossing();
            balloonManager.RemoveBalloons();
        }

        private void balloonTimer_Tick(object sender, EventArgs e)
        {
            balloonTimer.Interval = random.Next(1000, 3000);
            balloonManager.CreateBalloon();
        }
        public void CheckBalloonColor(Balloon balloon)
        {
            if (balloon.balloonColor == BalloonColor.Yellow)
            {
                YellowBalloon();
            }
            else if (balloon.balloonColor == BalloonColor.Red)
            {
                RedBalloon(balloon);
            }
            else if (balloon.balloonColor == BalloonColor.Blue)
            {
                BlueBalloon(balloon);
            }
        }
        public void LabelChange(Label label, int num)
        {
            label.Text = (int.Parse(label.Text) + num).ToString();
        }

        public void GameOver()
        {
            resultLbl.Text = "Game Over";
            archerSpeed = 0;
            gameState = "Game Over"; 
        }

        private void arrowSpeedTimer_Tick(object sender, EventArgs e)
        {
            arrowSpeedTimer.Enabled = false;
            arrowSpeed = 7;
        }
        public void ArrowSpeedIncrease(int num)
        {
            arrowSpeedTimer.Enabled = false;
            arrowSpeed += num;
            arrowSpeedTimer.Enabled = true;
        }
        public void BalloonCrossing()
        {
            foreach (Balloon ball in balloons)
            {
                if (ball.isBalloonCross == true && ball.balloonColor == BalloonColor.Red)
                {
                    if (balloonCount == 8)
                    {
                        GameOver();
                    }
                    else if (balloonCount < 8)
                    {
                        balloonCount++;
                        balloonCrossingLbl.Text = balloonCount.ToString();
                    }
                }
            }
        }
        public void YellowBalloon()
        {
            GameOver();
        }
        public void RedBalloon(Balloon balloon)
        {
            balloon.ID = balloon.ID + 1;
            foreach (Balloon ball in balloons)
            {
                if (ball.ID == 1)
                {
                    LabelChange(pointsLbl, 1);
                    balloonsToRemove.Add(ball);
                    arrowSpeed++;
                }
            }
        }
        public void BlueBalloon(Balloon balloon)
        {
            balloon.ID = balloon.ID + 1;
            foreach (Balloon ball in balloons)
            {
                if (ball.ID == 1)
                {
                    LabelChange(arrowCountLbl, 2);
                    arrowCount += 2;
                    LabelChange(pointsLbl, 1);
                    balloonsToRemove.Add(ball);
                    ArrowSpeedIncrease(15);
                }
            }
        }
    }
}

