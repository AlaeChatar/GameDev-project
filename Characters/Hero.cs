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

namespace GameDev_project.Characters
{
    internal class Hero : IGameObject
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(100, 900);
        private Vector2 velocity;
        private Rectangle rectangle;

        private bool hasJumped = false;

        public Vector2 Position 
        { 
            get { return position; }
            set {
                position.X = value.X;
                position.Y = value.Y;
                position = value; 
            }
        }
        public Rectangle HitBox { get; set; }

        public Hero(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);

            Input(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

            if (Keyboard.GetState().IsKeyDown(Keys.R))
                position = new Vector2(100, 900);

            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        private void Input(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            // Om te vermeiden dat lag invloed heeft op onze movement
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Brown);
        }
    }
}
