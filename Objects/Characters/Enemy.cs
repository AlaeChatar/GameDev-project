using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters
{
    internal class Enemy : Object
    {
        public bool turn;
        public bool bounce;

        private int limit1;
        private int limit2;

        public void Turn()
        {
            if (currentState == Gamestates.Level1)
            {
                if (position.Y == 900)
                {
                    limit1 = 860;
                    limit2 = 430;
                }
                else if (position.Y == 420)
                {
                    limit1 = 430;
                    limit2 = 60;
                }
            }
            else
            {
                if (position.Y == 480)
                {
                    limit1 = 1830;
                    limit2 = 1380;
                }
                else if (position.Y == 630)
                {
                    limit1 = 1470;
                    limit2 = 1120;
                }
                else if (position.Y == 750)
                {
                    limit1 = 1030;
                    limit2 = 800;
                }
            }

            // Enemy go left and right
            if (turn == false)
            {
                position.X += 3;
                if (position.X >= limit1)
                    turn = true;
            }
            if (turn == true)
            {
                position.X -= 3;
                if (position.X <= limit2)
                    turn = false;
            }
        }

        public void Bounce()
        {
            if (currentState == Gamestates.Level1)
            {
                if (position.X == 1020)
                {
                    limit1 = 700;
                    limit2 = 1080;
                }
                else
                {
                    limit1 = 430;
                    limit2 = 60;
                }
            }
            else
            {
                if (position.X == 1090 ||
                    position.X == 700 ||
                    position.X == 570 ||
                    position.X == 330)
                {
                    limit1 = 700;
                    limit2 = 1080;
                }
                else if (position.X == 840 ||
                         position.X == 1020 ||
                         position.X == 1200 ||
                         position.X == 1380)
                {
                    limit1 = 100;
                    limit2 = 390;
                }
            }

            // Enemy go up and down
            if (bounce == false)
            {
                position.Y -= 5;
                if (position.Y <= limit1)
                    bounce = true;
            }
            if (bounce == true)
            {
                position.Y += 5;
                if (position.Y >= limit2)
                    bounce = false;
            }
        }
    }
}
