using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters.Enemies.Movement
{
    internal class Jump : IEnemyBehavior
    {
        public int limit1 { get; set; }
        public int limit2 { get; set; }
        private Vector2 position;
        Vector2 IEnemyBehavior.Position { get => position; set => position = value; }
        private bool flip;
        bool IEnemyBehavior.Flip { get => flip; set => flip = value; }

        public Jump(Vector2 position)
        {
            this.position = position;
        }

        public void Move()
        {
            if (CurrentState == GameStates.Level1)
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
            if (flip == false)
            {
                position.Y -= 3;
                if (position.Y <= limit1)
                    flip = true;
            }
            if (flip == true)
            {
                position.Y += 3;
                if (position.Y >= limit2)
                    flip = false;
            }
        }
    }
}
