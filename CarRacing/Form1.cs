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
            Over.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        Random r = new Random();
        int x, y;

        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(0, 100);
                enemy1.Location = new Point(x, 0);
            }
            else enemy1.Top += speed;

            if (enemy2.Top >= 500)
            {
                x = r.Next(0, 200);
                enemy2.Location = new Point(x, 0);
            }
            else enemy2.Top += speed;

            if (enemy3.Top >= 500)
            {
                x = r.Next(100, 175);
                enemy3.Location = new Point(x, 0);
            }
            else enemy3.Top += speed;
        }

        void coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                x = r.Next(0, 100);
                coin1.Location = new Point(x, 0);
            }
            else coin1.Top += speed;

            if (coin2.Top >= 500)
            {
                x = r.Next(0, 100);
                coin2.Location = new Point(x, 0);
            }
            else coin2.Top += speed;

            if (coin3.Top >= 500)
            {
                x = r.Next(50, 150);
                coin3.Location = new Point(x, 0);
            }
            else coin3.Top += speed;

            if (coin4.Top >= 500)
            {
                x = r.Next(0, 200);
                coin4.Location = new Point(x, 0);
            }
            else coin4.Top += speed;
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

        void gameOver()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                Over.Visible = true;
            }

            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                Over.Visible = true;
            }

            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                Over.Visible = true;
            }
        }

        void coinsCollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedCoin++;
                label1.Text = "Coins=" + collectedCoin.ToString();
                x = r.Next(0, 100);
                coin1.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedCoin++;
                label1.Text = "Coins=" + collectedCoin.ToString();
                x = r.Next(0, 200);
                coin2.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedCoin++;
                label1.Text = "Coins=" + collectedCoin.ToString();
                x = r.Next(100, 350);
                coin3.Location = new Point(x, 0);
            }

            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedCoin++;
                label1.Text = "Coins=" + collectedCoin.ToString();
                x = r.Next(0, 400);
                coin4.Location = new Point(x, 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gameSpeed);
            enemy(gameSpeed);
            gameOver();
            coins(gameSpeed);
            coinsCollection();
        }

        int collectedCoin = 0;

        int gameSpeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if(car.Left>0)
                car.Left += -11;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(car.Right<280)
                car.Left += 11;
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
