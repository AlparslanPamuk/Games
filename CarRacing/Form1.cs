using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void moveLine(int speed)
        {
            if (pictureboxx1.Top >= 500)
            {
                pictureboxx1.Top = 0;
            }
            else pictureboxx1.Top += speed;

            if (pictureboxx3.Top >= 500)
            {
                pictureboxx3.Top = 0;
            }
            else pictureboxx3.Top += speed;

            if (pictureboxx4.Top >= 500)
            {
                pictureboxx4.Top = 0;
            }
            else pictureboxx4.Top += speed;

            if (pictureboxx5.Top >= 500)
            {
                pictureboxx5.Top = 0;
            }
            else pictureboxx5.Top += speed;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gameSpeed);
        }

        int gameSpeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if(car.Left>0)
                car.Left += -8;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(car.Right<280)
                car.Left += 8;
            }

            if (e.KeyCode == Keys.Up)
            {
                if (gameSpeed < 21)
                    gameSpeed++;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gameSpeed > 0)
                    gameSpeed--;
            }
        }
    }

    
}
