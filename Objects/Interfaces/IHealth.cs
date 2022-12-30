using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Interfaces
{
    internal interface IHealth
    {
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }
        public float Invulnerability { get; set; }
        void TakeDamage(GameTime gameTime, Vector2 position);
        Vector2 Respawn(Vector2 position, int health);
    }
}
