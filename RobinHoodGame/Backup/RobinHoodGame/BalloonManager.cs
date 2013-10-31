using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobinHoodGame.GameObjects;
using System.Drawing;
using RobinHoodGame.Properties;
using System.Windows.Forms;

namespace RobinHoodGame
{
    public class BalloonManager
    {
        private Balloon balloon;
        private Random random = new Random();
        
        private List<Balloon> balloons = new List<Balloon>();
        private List<Balloon> balloonsToRemove = new List<Balloon>();
        private List<Balloon> scoreBalloons = new List<Balloon>();
        private LevelBase levelBase;

        public BalloonManager(UserControl userControl)
        {
            userControl = levelBase;
        }

        public void CreateBalloon()
        {
            balloon = new Balloon();
            balloon.ID = 0;
            HandleBalloonColor(balloon);
            balloon.balloonSpeed = -random.Next(1, 5);

            int balloonXLocation = random.Next(levelBase.Right - 300, levelBase.Right - balloon.Width);
            int balloonYLocation = levelBase.Bottom;
            balloon.Location = new Point(balloonXLocation, balloonYLocation);
            balloons.Add(balloon);
            levelBase.Controls.Add(balloon);
        }
        public void RemoveBalloons()
        {
            foreach (Balloon balloon in balloonsToRemove)
            {
                balloons.Remove(balloon);
                levelBase.Controls.Remove(balloon);
            }
        }

        public void HandleBalloonSpeed()
        {
            foreach (Balloon balloon in balloons)
            {
                if (balloon.Bottom > levelBase.Top)
                {
                    balloon.OffSet(0, balloon.balloonSpeed);
                }
                else if (balloon.Bottom <= levelBase.Top)
                {
                    balloon.isBalloonCross = true;
                    balloonsToRemove.Add(balloon);
                }
            }
        }
        public void HandleBalloonColor(Balloon balloon)
        {
            int colorProb = random.Next(0, 20);
            if (colorProb > 5)
            {
                balloon.balloonColor = BalloonColor.Red;
            }
            else if (colorProb <= 2)
            {
                balloon.balloonColor = BalloonColor.Yellow;
                balloon.Image = Resources.balloonYellow;
            }
            else if (colorProb <= 5 && colorProb > 2)
            {
                balloon.balloonColor = BalloonColor.Blue;
                balloon.Image = Resources.balloonBlue;
            }
        }
       
     
      
    }
}
