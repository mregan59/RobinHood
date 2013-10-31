using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobinHoodGame.GameObjects;
using System.Drawing;

namespace RobinHoodGame
{

    public class ArrowManager
    {
        public List<Arrow> arrows = new List<Arrow>();
        private LevelBase level;
        public ArrowManager(UserControl userControl)
        {
            level = userControl as LevelBase;
        }


        public void ArrowSpeedIncrease(int num)
        {
            level.arrowSpeedTimer.Enabled = false;
            level.arrowSpeed += num;
            level.arrowSpeedTimer.Enabled = true;
        }

        public void HandleArrowVelocity(int arrowSpeed)
        {

            foreach (Arrow arrow in arrows)
            {
                if (arrow.Left <= level.Right)
                {
                    arrow.OffSet(arrowSpeed, 0);
                }
                else if (arrow.Left >= level.Right)
                {
                    level.Controls.Remove(arrow);
                }
            }
        }
        public void Shoot(Archer archer, Label label)
        {
            if (arrows.Count < level.arrowCount)
            {
                Arrow arrow = new Arrow();
                arrows.Add(arrow);
                arrow.Location = new Point(archer.Location.X, archer.Location.Y + 7);
                level.Controls.Add(arrow);
                label.Text = (int.Parse(label.Text) - 1).ToString();
            }
        }
    }      
}
