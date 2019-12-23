using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap SpaceShipTexture = Resource1.Space_Ship, AlienTexture = Resource1.Alien, alienShot = Resource1.shot_ship, shipShot = Resource1.shot_alien, kaboom = Resource1.Kaboom, gameOver = Resource1.GameOver, youWin = Resource1.YouWin;
        Game game = new Game();
        int pozition;
        //public bool gameOver = false;
        bool active = false;
        public int shipX = 0;
        private int a = 0;
        private bool [] cheater = new bool[4];
        bool[] kC = new bool[10];
        bool menu = true;
        bool sound = false;
        int c = 0;
        int j = 0;
        


        public Form1()
        {
            for (int i = 0; i < 4; i++)
            {
                game.shoot[i] = new Shoot1();
            }
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            pozition = this.Width - 50;

           

            UpdateStyles();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        private void Timer_1Tick(object sender, EventArgs e)
        {
            Refresh();
            pictureBox1.Refresh();
            game.Shoot();
            if (sound)
            {
                j++;
            }
            if (j == 200)
            {
                for (int i = 0; i < 18; i++)
                {
                    game.aliens[i].deleted = true;
                }
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            game.ShootMovement(this.Height, shipX);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W && !game.shoot[3].exist)
            {
                game.ShipShoot(this.Height, shipX);
                active = true;
            }
            if (e.KeyCode == Keys.D)
            {
                shipX += 35;
            }
            if (e.KeyCode == Keys.A)
            {
                shipX -= 35;
            }


            if (e.KeyCode == Keys.F12 && cheater[0])
            {
                for (int i = 0; i < 18; i++)
                {
                    game.aliens[i].deleted = true;
                }
            }
            if (e.KeyCode == Keys.F4 && cheater[0])
            {
                game.m = 50;
            }
            if(e.KeyCode == Keys.F6 && cheater[0])
            {
                game.ysm = 50;
            }
            if(e.KeyCode == Keys.Insert)
            {
                cheater[0] = true;
            }
            if(e.KeyCode == Keys.Delete && cheater[0])
            {
                cheater[0] = false;
            }


            if(e.KeyCode == Keys.Up && !kC[0])
            {
                kC[0] = true;
            }
            if (e.KeyCode == Keys.Up && kC[0])
            {
                kC[1] = true;
            }
            if (e.KeyCode == Keys.Down && kC[1])
            {
                kC[2] = true;
            }
            if (e.KeyCode == Keys.Down && kC[2])
            {
                kC[3] = true;
            }
            if (e.KeyCode == Keys.Left && kC[3])
            {
                kC[4] = true;
            }
            if (e.KeyCode == Keys.Right && kC[4])
            {
                kC[5] = true;
            }
            if (e.KeyCode == Keys.Left && kC[5])
            {
                kC[6] = true;
            }
            if (e.KeyCode == Keys.Right && kC[6])
            {
                kC[7] = true;
            }
            if (e.KeyCode == Keys.B && kC[7])
            {
                kC[8] = true;
            }
            if (e.KeyCode == Keys.A && kC[8] && !sound)
            {
                sound = true;
                timer2.Enabled = false;
                timer3.Enabled = false;
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\mushr\Desktop\Space Invaders\Dio.wav");
                simpleSound.Play();
                
                
            }
        }

        private void Timer2_Tick(object sender, EventArgs e) //Передвижения иноплпнитянинов
        {
            game.Movement(pozition);
            c++;
            if (c >= 10)
            {
                game.m++;
                c = 0; 
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Picturebox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;

            Graphics g = e.Graphics;

            if (!game.alive)
            {
                timer2.Enabled = false;
                timer1.Enabled = false;
                timer3.Enabled = false;
            }
            var SpaceShipRect = new Rectangle(shipX, this.Height-115, 75, 75); //Присвоение положения корабля

            if (game.alive)
            {
                e.Graphics.DrawImage(SpaceShipTexture, SpaceShipRect); //Положение корабля
            }
            if (!game.alive)
            {
                e.Graphics.DrawImage(kaboom, SpaceShipRect); //Отрисовка при проигрыше корабля
                e.Graphics.DrawImage(gameOver, new Rectangle(this.Width /4, this.Height /4, 500, 500));

            }

            for (int i = 0; i < 18; i++)
            {
                int num = game.aliens[i].alienY;
                if (num >= this.Height - 90)
                {
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    e.Graphics.DrawImage(gameOver, new Rectangle(this.Width/4, this.Height/4, 500, 500));
                }
                if (!game.aliens[i].deleted)
                {
                    g.DrawImage(AlienTexture, new Rectangle(game.aliens[i].alienX, game.aliens[i].alienY, 75, 75));
                }
            }
            for (int i = 0; i <18; i++)
            {
                
                if (!game.aliens[i].deleted)
                {
                    a = 0;
                    break;
                }
                else
                {
                    a++;
                }
                if(a == 17)
                {
                    e.Graphics.DrawImage(youWin, new Rectangle(this.Width / 4, this.Height / 4, 1000, 500));
                    timer2.Enabled = false;
                    //    timer1.Enabled = false;
                    timer3.Enabled = false;
                }
            }
            a = 0;

            for (int i = 0; i < 3; i++)
            {
                g.DrawImage(alienShot, new Rectangle(game.shoot[i].shootX, game.shoot[i].shootY, 7, 50));
            }
            if (active && game.shoot[3].exist)
            {
                  g.DrawImage(shipShot, new Rectangle(game.shoot[3].shootX, game.shoot[3].shootY, 7, 50));

            }
            

        }
    }
}

