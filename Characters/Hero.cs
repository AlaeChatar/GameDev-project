using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Color hurt;
        private bool right;
        private bool left;

        // IHealth
        public bool IsDead { get; set; }
        public int Health { get; set; }
        public bool IsHit { get; set; }

        public float invulnerability;
        private bool hasJumped = false;


        public Hero(Texture2D textureRight, Texture2D textureLeft, Vector2 position)
        {
            this.textureRight = textureRight;
            this.textureLeft = textureLeft;
            this.position = position;
            Health = 3;
            IsDead = false;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textureRight.Width, textureRight.Height, 6, 1);
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
            // Om te vermeiden dat lag invloed heeft op onze movement
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                right = true;
                left = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                left = true;
                right = false;
            }
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
            if (HitBox.TouchTopOf(newRect))
            {
                hitBox.Y = newRect.Y - hitBox.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (hitBox.TouchLeftOf(newRect))
                position.X = newRect.X - hitBox.Width - 2;
            if (hitBox.TouchRightOf(newRect))
                position.X = newRect.X + newRect.Width + 2;
            if (hitBox.TouchBottomOf(newRect))
                velocity.Y = 1f;

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - hitBox.Width) position.X = xOffset - hitBox.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > xOffset - hitBox.Height) position.Y = yOffset - hitBox.Height;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            Input(gameTime);
            
            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            Respawn();
            TakeDamage(gameTime);

            if (invulnerability <= 0)
                hurt = Color.White;
            else
                hurt = Color.Black;

            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (right == true)
                spriteBatch.Draw(textureRight, new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, hurt);
            if (left == true)
                spriteBatch.Draw(textureLeft, new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, hurt);
        }
    }
}
