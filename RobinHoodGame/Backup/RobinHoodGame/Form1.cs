using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobinHoodGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            Form2 instructions = new Form2();
            instructions.ShowDialog();
            InitializeComponent();
        }
    }
}
