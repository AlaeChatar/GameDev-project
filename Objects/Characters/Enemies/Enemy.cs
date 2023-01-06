using GameDev_project.Gamescreens;
using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters.Enemies
{
    internal class Enemy : Object
    {
        protected IEnemyBehavior enemyBehavior;
        public override Vector2 Position { get => enemyBehavior.Position; set => base.Position = value; }
        protected bool turn;
        public bool Flip { get => enemyBehavior.Flip; set => Flip = value; }


        public void PerformMovement()
        {
            enemyBehavior.Move();
        }
    }
}
