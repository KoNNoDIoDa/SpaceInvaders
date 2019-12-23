using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class Game
    {
        public Aliens[] aliens = new Aliens[18];
        bool f = true;
        public Shoot1[] shoot = new Shoot1[4]; 
        public bool alive = true;
        int[] random = new int[3];
        int[] tru = new int[6];
        bool[] moving = new bool[3];
        internal int[] g = { 12, 12, 12, 12, 12, 12 };
        internal int m = 3;
        internal int sm = 5;
        internal int ysm = 15;





        public Game()
        {
            int x = 0, y = 10,c=0;

            for (int a = 0; a < 3; a++)
            {
                for (int i = 0; i < 6; i++)
                {
                    x += 105;
                    aliens[c] = new Aliens();
                    aliens[c].alienX = x;
                    aliens[c].alienY = y;
                    c++;
                }
                x = 0;
                y += 75;
            }
        }

        public void Movement( int wdth)
        {
            int num=0;
            int lens = wdth - 45;
            

            for (int i =0; i<18; i++)
            {
                if (!aliens[i].deleted)
                {
                    num = aliens[i].alienX;
                }

                if (num >= lens)
                {
                    f = false;
                    break;
                }
                if (num <= 50)
                {
                    f = true;
                    break;
                }
               
            }

            if (f)
            {
                for (int i = 0; i < 18; i++)
                {
                    aliens[i].alienX += m;
                }
            }
            if (!f)
            {
                {
                    for (int i = 0; i < 18; i++)
                    {
                        aliens[i].alienX -= m;
                    }
                }
            }
            if (num <= 50 || num >= lens)
            {
                for (int i = 0; i < 18; i++)
                {
                    aliens[i].alienY += 50;
                }
            }


        }

        public void Shoot()
        {
            int b = 0;
            int r = 0;
            int rn = 0;
            int rrn = 0;

            Random rnd = new Random();


            r = rnd.Next(0,2);
            rn = rnd.Next(2,3);
            rrn = rnd.Next(4,5);
            if (g[r] >= 0)
            {
                aliens[r + g[r]].active = true;
            }
            if (g[rn] >= 0)
            {
                aliens[rn + g[rn]].active = true;
            }
            if (g[rrn] >= 0)
            {
                aliens[rrn + g[rrn]].active = true;
            }

            for (int i = 0; i < 18; i++)
            {
                
                if (aliens[i].active && !shoot[b].exist && !aliens[i].deleted)
                { 
                    shoot[b].exist = true;
                    shoot[b].shootX = aliens[i].alienX + 25;
                    shoot[b].shootY = aliens[i].alienY + 50;
                    b++;
                }

            }
            aliens[r + g[r]].active = false;
            aliens[rn + g[rn]].active = false;
            aliens[rrn + g[rrn]].active = false;

            if (aliens[r + g[r]].deleted && g[r]!=0)
            {
                g[r] -= 6;
            }
            if (aliens[rn + g[rn]].deleted && g[rn] != 0)
            {
                g[rn] -= 6;
            }
            if (aliens[rrn + g[rrn]].deleted && g[rrn] != 0)
            {
                g[rrn] -= 6;
            }

            if (b > 2)
                {
                    b = 0;
                }
            }


        public void ShootMovement(int height, int shipX)
        {
            for (int c = 0; c < 4; c++)
            {
                if (shoot[c].exist && !shoot[c].your)
                {
                    for (int i = 0;  i < 3; i++)
                    {
                        shoot[i].shootY += sm;

                    }
                }

                if (shoot[c].exist && shoot[c].your)
                {
                        shoot[c].shootY -= ysm;
                }

                if (shoot[c].shootY >= height && !shoot[c].your)
                {
                    shoot[c].exist = false;
                }

                if (shoot[c].shootY <= 0 && shoot[c].your)
                {
                    shoot[c].exist = false;
                }

                if (shoot[c].shootY <= height - 90 && shoot[c].shootY >= height - 140 && shoot[c].shootX >= shipX && shoot[c].shootX <= shipX + 50 && !shoot[c].your) //Попадание
                {
                    shoot[c].exist = false;
                    alive = false;
                    
                }

                for (int a = 0; a < 18; a++)
                {
                    if (aliens[a].alienX <= shoot[3].shootX && aliens[a].alienX + 50 >= shoot[3].shootX && aliens[a].alienY <= shoot[3].shootY && aliens[a].alienY + 50 >= shoot[3].shootY && !aliens[a].deleted)
                    {
                        aliens[a].deleted = true;
                        shoot[3].exist = false;   
                    }
                }

                if (!shoot[3].exist)
                {
                    shoot[3].shootX = 0;
                    shoot[3].shootY = 0;
                }
                
            }
            
        }

        public void ShipShoot(int height, int shipX)
        {
                shoot[3].exist = true;
                shoot[3].shootX = shipX + 32;
                shoot[3].shootY = height - 144;
                shoot[3].your = true;

        }

    }
    }

