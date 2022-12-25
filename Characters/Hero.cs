using GameDev_project.Collision;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Characters
{
    internal class Hero : Character, IGameObject, IHealth
    {
        private Vector2 velocity;
        public Vector2 Position 
        { 
            get { return position; }
            set {
                position.X = value.X;
                position.Y = value.Y;
                position = value; 
            }
        }

        // Interaction
        public bool IsDead { get; set; }
        public int Health { get; set; }
        public bool IsHit { get; set; }
        public float invulnerability;
        private bool hasJumped = false;


        public Hero(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            Health = 3;
            IsDead = false;
        }

        public void TakeDamage(GameTime gameTime)
        {
            //invincible timer
            invulnerability -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (IsHit == true && invulnerability <= 0)
            {
                //voor hoelang is die invincible na een hit
                invulnerability = 0.5f;
                Health--;
            }

            if (Health <= 0 || position.Y >= 1080)
                IsDead = true;
        }

        public void Respawn()
        {
            if (currentState == Gamestates.Level1 && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                IsHit = false;
                IsDead = false;
                Health = 3;
                position = new Vector2(100, 900);
            }
            if (currentState == Gamestates.Level2 && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                IsHit = false;
                IsDead = false;
                Health = 3;
                position = new Vector2(100, 350);
            }
        }

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            // Om te vermeiden dat lag invloed heeft op onze movement
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else velocity.X = 0f;

            if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Space)) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRect, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRect))
            {
                rectangle.Y = newRect.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (rectangle.TouchLeftOf(newRect))
                position.X = newRect.X - rectangle.Width - 2; 
            if (rectangle.TouchRightOf(newRect))
                position.X = newRect.X + newRect.Width + 2;
            if (rectangle.TouchBottomOf(newRect))
                velocity.Y = 1f;

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > xOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;

        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);

            Input(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            Respawn();
            TakeDamage(gameTime);

            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (invulnerability <= 0)
                spriteBatch.Draw(texture, rectangle, Color.Yellow);
            else
            {
                spriteBatch.Draw(texture, rectangle, Color.Red);
                IsHit = false;
            }
        }
    }
}
