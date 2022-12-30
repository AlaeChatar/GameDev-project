using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.LifeSpan
{
    internal class Life : IHealth
    {
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }
        public float Invulnerability { get; set; }

        public Life(int Health)
        {
            this.Health = Health;
        }

        public void TakeDamage(GameTime gameTime, Vector2 position)
        {
            //invincible timer
            Invulnerability -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (IsHit == true && Invulnerability <= 0)
            {
                //voor hoelang is die invincible na een hit
                Invulnerability = 0.5f;
                Health--;
            }

            if (Health <= 0 || position.Y >= 1080)
                IsDead = true;
        }

        public  Vector2 Respawn(Vector2 position, int health)
        {
            if (currentState == Gamestates.Level1 && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                IsHit = false;
                IsDead = false;
                Health = health;
                return new Vector2(100, 900);
            }
            if (currentState == Gamestates.Level2 && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                IsHit = false;
                IsDead = false;
                Health = health;
                return new Vector2(100, 350);
            }

            return position;
        }
    }
}
