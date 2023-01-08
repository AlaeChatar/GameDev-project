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
        private Vector2 position;
        Vector2 IEnemyBehavior.Position { get => position; set => position = value; }
        private bool turn;
        bool IEnemyBehavior.Turn { get => turn; set => turn = value; }
        public int Limit1 { get; set; }
        public int Limit2 { get; set; }

        public TurnAround(Vector2 position, bool turn)
        {
            this.position = position;
            this.turn = turn;
        }

        public void Movement()
        {
            if (CurrentState == GameStates.Level1)
            {
                if (position.Y == 900)
                {
                    Limit1 = 860;
                    Limit2 = 430;
                }
                else if (position.Y == 420 && position.X == 60)
                {
                    Limit1 = 430;
                    Limit2 = 60;
                }
                else if (position.Y == 420 && position.X == 1400)
                {
                    Limit1 = 1790;
                    Limit2 = 1400;
                }
            }
            else
            {
                if (position.Y == 480)
                {
                    Limit1 = 1830;
                    Limit2 = 1380;
                }
                else if (position.Y == 630)
                {
                    Limit1 = 1470;
                    Limit2 = 1120;
                }
                else if (position.Y == 750)
                {
                    Limit1 = 1030;
                    Limit2 = 800;
                }
            }

            // Enemy go left and right
            if (turn == false)
            {
                position.X += 1;
                if (position.X >= Limit1)
                    turn = true;
            }
            if (turn == true)
            {
                position.X -= 1;
                if (position.X <= Limit2)
                    turn = false;
            }
        }
    }
}
