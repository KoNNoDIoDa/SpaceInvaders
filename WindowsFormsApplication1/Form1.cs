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
        Bitmap SpaceShipTexture = Resource1.Space_Ship, AlienTexture = Resource1.Alien, alienShot = Resource1.shot_ship, shipShot = Resource1.shot_alien;
        Game game=new Game();
        int pozition;
        int i = 0;
        int b = 0;
        bool deleted = false;
        int update;

        public Form1()
        {
            for(int i = 0; i < 3; i++)
            {
                game.shoot[i] = new Shoot1();
            }
            InitializeComponent();

            

            for (int a = 0; a < 1801; a -= 100)
            {
               
                game.up[i] = a;
            }

            update = timer2.Interval;

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            game.AlienPosition();
            pozition = this.Width - 50;

           

            UpdateStyles();
        }

        private void Timer_1Tick(object sender, EventArgs e)
        {
            
            Refresh();
            pictureBox1.Refresh();
            for (int i = 0; i > 18; i++)
            {
                update = game.up[b];
                deleted = game.aliens[i].deleted;
                if (!deleted)
                {
                    b++;
                }
            }
            game.Shoot();


        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            game.ShootMovement(this.Height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e) //Передвижения иноплпнитянинов
        {
            game.Movement(pozition);
            
            //pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Picturebox1_Paint(object sender, PaintEventArgs e)
        {

            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;

            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position); //Присвоение положения инопланетянинов
            var SpaceShipRect = new Rectangle(localPosition.X, this.Height - 90, 50, 50); //Присвоение положения корабля
            e.Graphics.DrawImage(SpaceShipTexture, SpaceShipRect); //Положение корабля

            for (int i = 0; i < 18; i++)
            {
                g.DrawImage(AlienTexture, new Rectangle(game.aliens[i].alienX, game.aliens[i].alienY, 50, 50));
            }

            for (int i = 0; i < 3; i++)
            {
                //game.shoot[i] = new Shoot1();
                g.DrawImage(alienShot, new Rectangle(game.shoot[i].shootX, game.shoot[i].shootY, 5, 35));
            }

            //g.DrawImage(shipShot, new Rectangle(100, 100, 5, 35));
            //g.DrawImage(alienShot, new Rectangle(200, 200, 5, 35));

            SpaceShipRect = new Rectangle(/*game.aliens[i].alienX, game.aliens[i].alienY*/localPosition.X, this.Height - 90, 50, 50); //Присвоение положения корабля
            e.Graphics.DrawImage(SpaceShipTexture, SpaceShipRect); //Положение корабля

        }
    }
}

