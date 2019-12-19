using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap SpaceShipTexture = Resource1.Space_Ship, AlienTexture = Resource1.Alien, alienShot = Resource1.shot_ship, shipShot = Resource1.shot_alien, kaboom = Resource1.Kaboom, gameOver = Resource1.GameOver;
        Game game = new Game();
        int pozition;
        //public bool gameOver = false;
        bool active = false;
        public int shipX = 0;

        public Form1()
        {
            for(int i = 0; i < 4; i++)
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

        private void Timer_1Tick(object sender, EventArgs e)
        {
            
            Refresh();
            pictureBox1.Refresh();
            game.Shoot();


        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            game.ShootMovement(this.Height, shipX);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W)
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
        }

        private void timer2_Tick(object sender, EventArgs e) //Передвижения иноплпнитянинов
        {
            game.Movement(pozition);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

            var localPosition = this.PointToClient(Cursor.Position); //Присвоение положения инопланетянинов
            var SpaceShipRect = new Rectangle(shipX, this.Height - 90, 50, 50); //Присвоение положения корабля

            if (game.alive)
            {
                e.Graphics.DrawImage(SpaceShipTexture, SpaceShipRect); //Положение корабля
            }
            if (!game.alive)
            {
                e.Graphics.DrawImage(kaboom, SpaceShipRect); //Отрисовка при проигрыше корабля
                e.Graphics.DrawImage(gameOver, new Rectangle(this.Width / 2, this.Height / 2, 500, 500));

            }

            for (int i = 0; i < 18; i++)
            {
                if (!game.aliens[i].deleted)
                g.DrawImage(AlienTexture, new Rectangle(game.aliens[i].alienX, game.aliens[i].alienY, 50, 50));
            }

            for (int i = 0; i < 3; i++)
            {
                g.DrawImage(alienShot, new Rectangle(game.shoot[i].shootX, game.shoot[i].shootY, 5, 35));
            }
            if (active && game.shoot[3].exist)
            {
                  g.DrawImage(shipShot, new Rectangle(game.shoot[3].shootX, game.shoot[3].shootY, 5, 35));

            }


        }
    }
}

