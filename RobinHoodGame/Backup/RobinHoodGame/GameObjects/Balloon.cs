using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RobinHoodGame.Properties;
using System.Windows.Forms;

namespace RobinHoodGame.GameObjects
{
    public class Balloon : GameObject
    {
        public int balloonSpeed { get; set; }
        public int ID { get; set; }
        public BalloonColor balloonColor { get; set; }
        public bool isBalloonCross = false;

        public Balloon()
        {
            
            Image = Resources.balloon;
            Size = new Size(50, 70);
        }
    }
    public enum BalloonColor
    { 
        Yellow, Blue, Red
    }
}
