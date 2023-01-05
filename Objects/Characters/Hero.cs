using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Objects.Interfaces;
using GameDev_project.Objects.LifeSpan;
using GameDev_project.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters
{
    internal class Hero : Object, IGameObject
    {
        public Vector2 velocity;
        private bool lookLeft;
        public bool hasJumped;

        public Hero(List<Texture2D> textures, Vector2 position)
        {
            this.textures = textures;
            this.position = position;
            velocity = new Vector2(2, 2);
            health = new Life(3);
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[2].Width, textures[2].Height, 4, 1);
            animation.GetFramesFromTextureProperties(textures[3].Width, textures[3].Height, 4, 1);
            animation.GetFramesFromTextureProperties(textures[4].Width, textures[4].Height, 6, 1);
        }

        public void Move(GameTime gameTime)
        {
            // Om te vermeiden dat lag invloed heeft op onze movement
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                lookLeft = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                lookLeft = true;
            }
            else velocity.X = 0f;

            if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Space)) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            Move(gameTime);
            if (velocity.Y < 10)
                velocity.Y += 0.4f;
            if (health.IsDead == true)
                position = health.Respawn(position, 3);
            if (health.IsHit == true)
                Sfx.Hurt();    
            health.TakeDamage(gameTime, position);
            hitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X == 0)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[2], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[2], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            }
            else if (lookLeft == false)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[0], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[0], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);

            }
            else if (lookLeft == true)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[1], new Vector2(position.X - 20, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[1], new Vector2(position.X - 20, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            }

            if (health.Health == 3)
            {
                spriteBatch.Draw(textures[5], new Vector2(position.X + 20, position.Y - 20), Color.White);
                spriteBatch.Draw(textures[5], new Vector2(position.X + 10, position.Y - 20), Color.White);
                spriteBatch.Draw(textures[5], new Vector2(position.X, position.Y - 20), Color.White);
            }
            else if (health.Health == 2)
            {
                spriteBatch.Draw(textures[5], new Vector2(position.X + 20, position.Y - 20), Color.Black);
                spriteBatch.Draw(textures[5], new Vector2(position.X + 10, position.Y - 20), Color.White);
                spriteBatch.Draw(textures[5], new Vector2(position.X, position.Y - 20), Color.White);
            }
            else if (health.Health == 1)
            {
                spriteBatch.Draw(textures[5], new Vector2(position.X + 20, position.Y - 20), Color.Black);
                spriteBatch.Draw(textures[5], new Vector2(position.X + 10, position.Y - 20), Color.Black);
                spriteBatch.Draw(textures[5], new Vector2(position.X, position.Y - 20), Color.White);
            }
        }
    }
}
