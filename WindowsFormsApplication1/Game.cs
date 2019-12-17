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

        //Form1 form = new Form1();
        public Aliens[] aliens = new Aliens[18];
        bool f = true;
        //public int[] up = new int[18];
        public Shoot1[] shoot = new Shoot1[4];
        int r = 0;
        int rn = 0;
        int rrn = 0;
        public bool alive = true;
        //bool[] fire = new bool[6];
        int[] random = new int[3];
        int[] tru = new int[6];
        bool[] moving = new bool[3];
        

        



        public Game()
        {
            int x = 0, y = 10,c=0;

            for (int a = 0; a < 3; a++)
            {
                for (int i = 0; i < 6; i++)
                {
                    x += 70;
                    aliens[c] = new Aliens();
                    aliens[c].alienX = x;
                    aliens[c].alienY = y;
                    c++;
                }
                x = 0;
                y += 50;
            }
            //for (int i = 0; i < 0; i++) {
            //    for (int a = 0; a < 18; a++)
            //    {
            //        if (aliens[a].alienX <= shoot[i].shootX && aliens[a].alienY >= shoot[i].shootY && !aliens[a].deleted)
            //        {
            //            aliens[a].deleted = true;
            //        }
            //    }
            //}
        }


        //public void AlienPosition()
        //{
        //    int x = 0, y = 0;
        //    for (int e = 0; e <= 3; e++)
        //    {
        //        for (int i = 0; i < 18; i++)
        //        {
        //            x += 70;
                    
        //        }
        //        y += 70;
        //    }
        //}

        public void Movement( int wdth)
        {
            int num=0;
            int lens = wdth - 45;
            

            for (int i =0; i<18; i++)
            {
                num = aliens[i].alienX;

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
                    aliens[i].alienX += 5;
                }
            }
            if (!f)
            {
                {
                    for (int i = 0; i < 18; i++)
                    {
                        aliens[i].alienX -= 5;
                    }
                }
            }
            if (num <= 25 || num >= lens)
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
            for (int i = 12; i < 18; i++)
            {
                aliens[i].armored = true;
            }

            Random rnd = new Random();


            r = rnd.Next(0,2);
            rn = rnd.Next(1,4);
            rrn = rnd.Next(3,6);

            aliens[r + 12].active = true;
            aliens[rn + 12].active = true;
            aliens[rrn + 12].active = true;
   
            for (int i = 0; i < 18; i++)
            {
                
                if (aliens[i].active && !shoot[b].exist)
                { 
                    shoot[b].exist = true;
                    shoot[b].shootX = aliens[i].alienX + 25;
                    shoot[b].shootY = aliens[i].alienY + 50;
                    b++;
                }

            }
            aliens[r + 12].active = false;
            aliens[rn + 12].active = false;
            aliens[rrn + 12].active = false;

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
                        shoot[i].shootY += 5;

                    }
                }

                if (shoot[c].exist && shoot[c].your)
                {
                        shoot[c].shootY -= 15;
                }

                if (shoot[c].shootY >= height && !shoot[c].your)
                {
                    shoot[c].exist = false;
                }

                if (shoot[c].shootY <= 0 && shoot[c].your)
                {
                    shoot[c].exist = false;
                }

                if (shoot[c].shootX < height - 90 && shoot[c].shootX > (height - 90) - 50 && shoot[c].shootY < shipX && shoot[c].shootY > shipX + 50 && !shoot[c].your) //Попадание
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
                shoot[3].shootX = shipX + 22;
                shoot[3].shootY = height - 90;
                shoot[3].your = true;

        }

    }
    }

