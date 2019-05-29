using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlowHockey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int yerX = -5, yerY = 5, puan = 0;
        private void CarpmaOlayı()
        {
            //Player 2 hareket
            player2.Location = new Point(ball.Location.X, player2.Location.Y);

            //Player 2 çarpma olayı
            if (ball.Top <= player2.Bottom)
            {
                yerY = yerY * -1;
                puan = puan + 10;
                lblpoint.Text = puan.ToString();
            }

            //Kontrole çarpma olayı

            if (ball.Bottom >= kontrol.Top && ball.Left >= kontrol.Left && ball.Right <= kontrol.Right)
            {
                yerY = yerY * -1;
            }

            //sağ kenara çarpma olayı
            else if (ball.Right >= label5.Left)
            {
                yerX = yerX * -1;
            }

            //sol kenara çarpma 
            else if (ball.Left <= label1.Right)
            {
                yerX = yerX * -1;
            }

            // sol alt kenar
            else if (ball.Bottom >= label3.Top && ball.Left <= label3.Right)
            {
                yerY = yerY * -1;
            }

            //sağ alt kenar
            else if (ball.Bottom >= label4.Top && ball.Right >= label4.Left)
            {
                yerY = yerY * -1;
            }
        }

        private void Game_Over(object sender, EventArgs e)
        {
            if (ball.Top >= label4.Bottom)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMe_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CarpmaOlayı();
            Game_Over(sender, e);
            ball.Location = new Point(ball.Location.X + yerX, ball.Location.Y + yerY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
