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
        public int arrowCount = 20;
        
        private Arrow arrow;
        private Balloon balloon;
        private Random random = new Random();
        
        
        private List<Balloon> balloonsToRemove;
        //private List<Balloon> scoreBalloons = new List<Balloon>();
        private string gameState;
        private BalloonManager balloonManager;
        private ArrowManager arrowManager;
        private int archerSpeed = 7;
        public int arrowSpeed = 8;
        public int fastArrowSpeed = 20;
        public int balloonCount = 8;

        public LevelBase()
        {
            InitializeComponent();
            
            gameState = "Running";
            balloonManager = new BalloonManager(this);
            arrowManager = new ArrowManager(this);
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
                    arrowManager.Shoot(archer, arrowCountLbl);
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
            foreach (Arrow arrow in arrowManager.arrows)
            {
                foreach (Balloon balloon in balloonManager.balloons)//change
                {
                    if (arrow.Bounds.IntersectsWith(balloon.Bounds))
                    {
                        balloon.Image = Resources.balloonPop;
                        CheckBalloonColor(balloon);
                    }
                }
            }
        }

        
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ArcherWallCollision();
            if (gameState == "Shooting"|| gameState == "Game Over")
            {
                arrowManager.HandleArrowVelocity(arrowSpeed);
            }
            balloonManager.HandleBalloonSpeed();
            ArrowBalloonCollision();
            BalloonCrossing();
            balloonManager.RemoveBalloons();
        }
        public void arrowSpeedTimer_Tick(object sender, EventArgs e)
                {
                    arrowSpeedTimer.Enabled = false;
                    arrowSpeed = 8;
                    archer.Image = Resources.archer;
            
                }
        private void balloonTimer_Tick(object sender, EventArgs e)
        {
            balloonTimer.Interval = random.Next(1000, 3000);
            balloonManager.CreateBalloon();
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
        public void BalloonCrossing()
        {
            if (balloonManager.CheckBalloonCrossing(balloonCount) == "gameOver")
            {
                GameOver();
            }
            else if (balloonManager.CheckBalloonCrossing(balloonCount) == "MinusOne")
            {
                balloonCount--;
                balloonCrossingLbl.Text = balloonCount.ToString();
            }
            else if (balloonManager.CheckBalloonCrossing(balloonCount) == "Null")
            {
                balloonCrossingLbl.Text = balloonCount.ToString();
            }
        }
        public void YellowBalloon()
        {
            GameOver();
        }
        public void RedBalloon(Balloon balloon)
        {
            balloon.ID = balloon.ID + 1;
           if (balloonManager.SearchBalloonList(balloon.ID, 1) == true)
                {
                    LabelChange(pointsLbl, 1);
                    balloonManager.balloonsToRemove.Add(balloon);
                    arrowSpeed++;
                }
        }
        public void BlueBalloon(Balloon balloon)
        {
            balloon.ID = balloon.ID + 1;
            {
                if (balloonManager.SearchBalloonList(balloon.ID, 1) == true)
                {
                    LabelChange(arrowCountLbl, 2);
                    arrowCount += 2;
                    LabelChange(pointsLbl, 1);
                    balloonManager.balloonsToRemove.Add(balloon);
                    arrowManager.ArrowSpeedIncrease(fastArrowSpeed);
                    archer.Image = Resources.archerFast;
                }
            }
        }
            
        
     }
        
    }


