using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RobinHoodGame.GameObjects
{
    public abstract class GameObject : PictureBox
    {
        public Size size { get; set; }

        public GameObject()
        {
            Location = new Point();
            SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        public void OffSet(int X, int Y)
        {
            Location = new Point(Location.X + X, Location.Y + Y);
        }
    }
}
