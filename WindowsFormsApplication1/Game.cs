﻿using System;
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
        public int[] up = new int[18];
        public Shoot1[] shoot = new Shoot1[3];
        int r = 0;
        int rn = 0;
        int rrn = 0;
        int a = 0;
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
        }


        public void AlienPosition()
        {
            int x = 0, y = 0;
            for (int e = 0; e <= 3; e++)
            {
                for (int i = 0; i < 18; i++)
                {
                    x += 70;
                }
                y += 70;
            }
        }

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
                    aliens[i].alienX += 50;
                }
            }
            if (!f)
            {
                {
                    for (int i = 0; i < 18; i++)
                    {
                        aliens[i].alienX -= 50;
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

            a = rnd.Next(9);
            r = rnd.Next(2) + 12;
            rn = rnd.Next(2, 4) + 12;
            rrn = rnd.Next(4, 6) + 12;

            if (a == 1 && )
            {
                shoot[0].exist = true;
                moving[0] = true;
                shoot[b] = new Shoot1();
                shoot[b].exist = true;
                shoot[b].shootX = aliens[r].alienX+25;
                shoot[b].shootY = aliens[r].alienY + 35;
                shoot[b].your = false;
                b++;

            }
            if (a == 2)
            {
                shoot[1].exist = true;
                moving[1] = true;
                shoot[b] = new Shoot1();
                shoot[b].exist = true;
                shoot[b].shootX = aliens[rn].alienX+25;
                shoot[b].shootY = aliens[rn].alienY + 35;
                shoot[b].your = false;
                b++;
            }
            if (a == 3)
            {
                shoot[2].exist = true;
                moving[2] = true;
                shoot[b] = new Shoot1();
                shoot[b].exist = true;
                shoot[b].shootX = aliens[rrn].alienX+25;
                shoot[b].shootY = aliens[rrn].alienY + 35;
                shoot[b].your = false;
                b++;
            }                 

            //for (int i =0; i < 3; i++)
            //{
            //        shoot[b] = new Shoot1();
            //        shoot[b].exist = true;
            //        shoot[b].shootX = aliens[i].alienX;
            //        shoot[b].shootY = aliens[i].alienY + 35;
            //        shoot[b].your = false;
            //        b++;

            //    }
            }
            

        public void ShootMovement(int height)
        {
            for(int c = 0; c < 3; c++)
            {
                if (moving[c])
                    for (int i = 0; i < 3; i++)
                    {
                        shoot[i].shootY += 35;
                    }
                if (shoot[c].shootY == height)
                {
                    moving[c] = false;
                }
            }
            
        }

        public void ShipShoot(object sender, KeyEventArgs e, int spiceShipX, int spiceShipY)
        {
            if (e.KeyCode == Keys.Space)
            {
                shoot[3].exist = true;
                shoot[3].shootX = spiceShipX;
                shoot[3].shootY = spiceShipY;
                shoot[3].your = true;

            }
        }

    }
    }

