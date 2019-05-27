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
        Direction our_direction;
        PictureBox[] pb_snakeParts;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Mustafa Alparslan Pamuk || Snake Game";
            pb_snakeParts = new PictureBox[0];
            for (int i = 0; i < 3; i++)
            {
                Array.Resize(ref pb_snakeParts, pb_snakeParts.Length + 1); // burdaki her eklendiği zaman bunu bir arttır dizinini uzunluğu.
                pb_snakeParts[i] = pb_add();
            }
        }
        private PictureBox pb_add()
        {

            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10);
            pb.BackColor = Color.White;
            pb.Location = Our_snake.GetPos(pb_snakeParts.Length - 1);
            panel1.Controls.Add(pb);

            return pb;
        }

        private void Pb_update()
        {
            for (int i = 0; i < pb_snakeParts.Length; i++)
            {
                pb_snakeParts[i].Location = Our_snake.GetPos(i);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                our_direction = new Direction(0, -10);

            }

            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                our_direction = new Direction(0, 10);

            }

            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                our_direction = new Direction(-10, 0);

            }

            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                our_direction = new Direction(10, 0);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Our_snake.Move(our_direction);
            Pb_update();
        }
    }
}    
    

