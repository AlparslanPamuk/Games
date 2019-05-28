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
        bool bait_exists = false;
        Random random = new Random();
        PictureBox pb_bait;
        PictureBox[] pb_snakeParts;

        private void Form1_Load(object sender, EventArgs e)
        {
            our_direction = new Direction(0, 0);
            this.Text = "Mustafa Alparslan Pamuk || Snake Game";
            pb_snakeParts = new PictureBox[0];
            for (int i = 0; i < 3; i++)
            {
                Array.Resize(ref pb_snakeParts, pb_snakeParts.Length + 1); // burdaki her eklendiği zaman bunu bir arttır dizinini uzunluğu.
                pb_snakeParts[i] = pb_add();
            }
            timer1.Start();
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
                if(our_direction._y != 10)
                {
                    our_direction = new Direction(0, -10);
                }                
            }

            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (our_direction._y != -10)
                {
                    our_direction = new Direction(0, 10);
                }                
            }

            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (our_direction._x != 10)
                {
                    our_direction = new Direction(-10, 0);
                }             
            }

            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (our_direction._x != -10)
                {
                    our_direction = new Direction(10, 0);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Our_snake.Move(our_direction);
            Pb_update();
        }

        public void create_bait()
        {
            PictureBox pb = new PictureBox();
            pb.BackColor = Color.Red;
            pb.Size = new Size(10, 10);
            pb.Location = new Point(random.Next(panel1.Width / 10) * 10,random.Next(panel1.Height /10)*10);
            pb_bait = pb;
            bait_exists = true;
            panel1.Controls.Add(pb);

        }

        public void bait_eaten()
        {
            if (Our_snake.GetPos(0)==pb_bait.Location)
            {
                Our_snake.Grow();
                Array.Resize(ref pb_snakeParts, pb_snakeParts.Length + 1);
                pb_snakeParts[pb_snakeParts.Length - 1] = pb_add();
                bait_exists = false;
                panel1.Controls.Remove(pb_bait);
            }
        }
    }
}    
    

