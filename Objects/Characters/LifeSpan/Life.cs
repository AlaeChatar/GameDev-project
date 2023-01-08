using GameDev_project.Gamescreens;
using GameDev_project.Objects.Characters;
using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters.LifeSpan
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
                Invulnerability = 1f;
                Health--;
            }

            if (Health <= 0 || position.Y >= 1080)
                IsDead = true;
        }

        public Vector2 Respawn(Vector2 position, int health)
        {
            IsHit = false;
            IsDead = false;
            Health = health;
            return position;
        }

        public void ShowHealth(SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
        {
            if (Health == 3)
            {
                spriteBatch.Draw(texture, new Vector2(position.X + 20, position.Y - 20), Color.White);
                spriteBatch.Draw(texture, new Vector2(position.X + 10, position.Y - 20), Color.White);
                spriteBatch.Draw(texture, new Vector2(position.X, position.Y - 20), Color.White);
            }
            else if (Health == 2)
            {
                spriteBatch.Draw(texture, new Vector2(position.X + 20, position.Y - 20), Color.Black);
                spriteBatch.Draw(texture, new Vector2(position.X + 10, position.Y - 20), Color.White);
                spriteBatch.Draw(texture, new Vector2(position.X, position.Y - 20), Color.White);
            }
            else if (Health == 1)
            {
                spriteBatch.Draw(texture, new Vector2(position.X + 20, position.Y - 20), Color.Black);
                spriteBatch.Draw(texture, new Vector2(position.X + 10, position.Y - 20), Color.Black);
                spriteBatch.Draw(texture, new Vector2(position.X, position.Y - 20), Color.White);
            }
        }
    }
}
