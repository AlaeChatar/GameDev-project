using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Objects.Characters.LifeSpan;
using GameDev_project.Objects.Interfaces;
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
        private bool lookLeft;
        private bool hasJumped;
        public bool HasJumped 
        { 
            get { return hasJumped; } 
            set { hasJumped= value; }
        }


        private Vector2 velocity;
        public Vector2 Velocity 
        { 
            get { return velocity; }
            set { velocity = value; }
        }

        private Life health;
        public Life Health 
        { 
            get { return health; } 
            set { health = value; } 
        }

        private Vector2 spawn;
        public Vector2 Spawn 
        { 
            get { return spawn; }
            set { spawn = value; }
        }

        public Hero(List<Texture2D> textures, Vector2 position, Life health)
        {
            this.textures = textures;
            this.Position = position;
            spawn = position;
            velocity = new Vector2(2, 2);
            this.health = health;
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
                Position -= new Vector2(0, 5f);
                velocity.Y = -9f;
                hasJumped = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            Position += velocity;
            Move(gameTime);
            if (velocity.Y < 10)
                velocity.Y += 0.4f;
            if (health.IsDead == true)
                Position = Health.Respawn(spawn, 3);
            if (health.IsHit == true)
                Sfx.Hurt();    
            Health.TakeDamage(gameTime, Position);
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X == 0)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[2], new Vector2(Position.X, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[2], new Vector2(Position.X, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            }
            else if (lookLeft == false)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[0], new Vector2(Position.X, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[0], new Vector2(Position.X, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);

            }
            else if (lookLeft == true)
            {
                if (health.Invulnerability >= 0)
                {
                    spriteBatch.Draw(textures[1], new Vector2(Position.X - 10, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.Red);
                    health.IsHit = false;
                }
                else
                    spriteBatch.Draw(textures[1], new Vector2(Position.X - 10, Position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            }

            health.ShowHealth(spriteBatch, textures[5], Position);
        }
    }
}
