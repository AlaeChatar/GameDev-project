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
    internal class TurnAround : IEnemyBehavior
    {
        public int limit1 { get; set; }
        public int limit2 { get; set; }
        private Vector2 position;
        Vector2 IEnemyBehavior.Position { get => position; set => position = value; }
        private bool flip;
        bool IEnemyBehavior.Flip { get => flip; set => flip = value; }

        public TurnAround(Vector2 position, bool flip)
        {
            this.position = position;
            this.flip = flip;
        }

        public void Move()
        {
            if (CurrentState == GameStates.Level1)
            {
                if (position.Y == 900)
                {
                    limit1 = 860;
                    limit2 = 430;
                }
                else if (position.Y == 420 && position.X == 60)
                {
                    limit1 = 430;
                    limit2 = 60;
                }
                else if (position.Y == 420 && position.X == 1400)
                {
                    limit1 = 1790;
                    limit2 = 1400;
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
            if (flip == false)
            {
                position.X += 1;
                if (position.X >= limit1)
                    flip = true;
            }
            if (flip == true)
            {
                position.X -= 1;
                if (position.X <= limit2)
                    flip = false;
            }
        }
    }
}
