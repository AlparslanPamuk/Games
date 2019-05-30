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

        int yerX = 5, yerY = 5, puan = 0, Can = 3, saniye=60,level =1;

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
                if (Can > 0)
                {
                    timer1.Stop();
                    Can--;
                    timer2.Stop();
                    MessageBox.Show("Game Over! Remaining Change =>" + Can.ToString());
                    Form1_Load(sender, e);
                }
                if (Can == 0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Game Over!", "Mustafa Alparslan Pamuk || Glow Hockey Game",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Exit();
                    Point_save();
                }
            }
            lblcan.Text = Can.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void top_basa()
        {
            ball.Location = new Point(358, 300);
            if (yerY > 0)
            {
                yerY = yerY * - 1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            levelUp();
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            panel1.Visible = false;
        }

        private void levelUp()
        {
            saniye--;
            if (saniye == 0)
            {
                timer1.Stop();
                timer2.Stop();
                level++;
              
                top_basa();
                if (yerX < 0)
                {
                    yerX = yerX - 1;
                }
                else yerX = yerX + 1;
                if (yerY < 0)
                {
                    yerY = yerY - 1;
                }
                else yerY = yerY + 1;
                lblannouncement.Text = "Contrats!   Level :" + level.ToString();
                levelAnnouncement();
                saniye = 60;
            }
            lblsaniye.Text = saniye.ToString();
            lbllevel.Text = level.ToString();
        }

        private  void levelAnnouncement()
        {
            //187; 227
            panel1.Visible = true;
            panel1.Location = new Point(187, 227);
                
        }

        private void Point_save()
        {
            if (puan > Settings1.Default.TopPoint)

            {
                Settings1.Default.TopPoint = puan;
                Settings1.Default.Save();
            }
            lbltoppoint.Text = Settings1.Default.TopPoint.ToString();
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
            lbltoppoint.Text = Settings1.Default.TopPoint.ToString();
            top_basa();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
    }
}
