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
        private Vector2 position;
        Vector2 IEnemyBehavior.Position { get => position; set => position = value; }
        private bool turn;
        bool IEnemyBehavior.Turn { get => turn; set => turn = value; }
        public int Limit1 { get; set; }
        public int Limit2 { get; set; }

        public Jump(Vector2 position)
        {
            this.position = position;
        }

        public void Movement()
        {
            if (CurrentState == GameStates.Level1)
            {
                if (position.X == 1020)
                {
                    Limit1 = 700;
                    Limit2 = 1080;
                }
                else
                {
                    Limit1 = 430;
                    Limit2 = 60;
                }
            }
            else
            {
                if (position.X == 1090 ||
                    position.X == 700 ||
                    position.X == 570 ||
                    position.X == 330)
                {
                    Limit1 = 700;
                    Limit2 = 1080;
                }
                else if (position.X == 840 ||
                         position.X == 1020 ||
                         position.X == 1200 ||
                         position.X == 1380)
                {
                    Limit1 = 100;
                    Limit2 = 390;
                }
            }

            // Enemy go up and down
            if (turn == false)
            {
                position.Y -= 3;
                if (position.Y <= Limit1)
                    turn = true;
            }
            if (turn == true)
            {
                position.Y += 3;
                if (position.Y >= Limit2)
                    turn = false;
            }
        }
    }
}
