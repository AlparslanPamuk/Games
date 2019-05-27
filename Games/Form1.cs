using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Snake Our_snake = new Snake();
        PictureBox[] pb_snakeParts;

        private void Form1_Load(object sender, EventArgs e)
        {
            pb_snakeParts = new PictureBox[0];
            for (int i = 0; i < 3; i++)
            {
                pb_snakeParts[i] = pb_add();
            }
        }
        private PictureBox pb_add()
        {
            Array.Resize(ref pb_snakeParts, pb_snakeParts.Length + 1);
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.White;
            pb.Location = Our_snake.GetPos(pb_snakeParts.Length - 1);
            return pb;
        }
    }
}
