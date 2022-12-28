using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Interfaces;
using GameDev_project.Movement;
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
    internal class Hero : Character, IGameObject, IHealth, IMovable
    {
        public Vector2 velocity;
        private bool lookLeft;
        public float invulnerability;
        public bool hasJumped;
        private IInputReader inputReader;
        private MovementManager movementManager;


        // IHealth
        public bool IsDead { get; set; }
        public int Health { get; set; }
        public bool IsHit { get; set; }
        public Vector2 Velocity 
        { 
            get { return velocity; }
            set { velocity = value; }
        }
        public IInputReader InputReader 
        { 
            get { return inputReader; }
            set { inputReader = value; } 
        }

        public Hero(List<Texture2D> textures, Vector2 position, IInputReader inputReader)
        {
            this.textures = textures;
            this.position = position;
            this.inputReader = inputReader;
            movementManager= new MovementManager();
            velocity = new Vector2(2,2);

            Health = 3;
            IsDead = false;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[2].Width, textures[2].Height, 4, 1);
            animation.GetFramesFromTextureProperties(textures[3].Width, textures[3].Height, 4, 1);
            animation.GetFramesFromTextureProperties(textures[4].Width, textures[4].Height, 2, 1);
            animation.GetFramesFromTextureProperties(textures[5].Width, textures[5].Height, 6, 1);
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

        //public void Move(GameTime gameTime)
        //{

        //    // Om te vermeiden dat lag invloed heeft op onze movement
        //    if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
        //    {
        //        velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
        //        lookLeft = false;
        //    }
        //    else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
        //    {
        //        velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
        //        lookLeft = true;
        //    }
        //    else velocity.X = 0f;

        //    if ((Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Space)) && hasJumped == false)
        //    {
        //        position.Y -= 5f;
        //        velocity.Y = -9f;
        //        hasJumped = true;
        //    }
        //}

        private void Move()
        {
            // position += velocity;
            movementManager.Move(this);

            //if (velocity.Y < 10)
            //    velocity.Y += 0.4f;
        }


        public void Update(GameTime gameTime)
        {
            // Move(gameTime);
            Move();
            Respawn();
            TakeDamage(gameTime);
            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Hitbox
            if (IsHit == false)
                spriteBatch.Draw(textures[6], hitBox, Color.Blue);
            else
            {
                spriteBatch.Draw(textures[6], hitBox, Color.Red);
                spriteBatch.Draw(textures[4], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
                if (invulnerability >= 0)
                    IsHit = false;
            }

            // Animation
            if (velocity.X == 0)
                spriteBatch.Draw(textures[2], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            else if (lookLeft == false)
                spriteBatch.Draw(textures[0], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
            else if (lookLeft == true)
                spriteBatch.Draw(textures[1], new Vector2(position.X - 20, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
