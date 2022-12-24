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
    internal class Enemy : IGameObject
    {
        private Texture2D texture;
        private Vector2 velocity;
        private Rectangle rectangle;
        private Vector2 position;
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
        public Rectangle HitBox { get; set; }
        public bool IsDead { get; set; }
        public int Hp { get; set; }
        public bool IsHit { get; set; }
        private bool turn;

        // Sprite
        //Animation animation;

        public Enemy(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            Hp = 1;
            IsDead = false;

            //animation.GetFramesFromTextureProperties(texture.Width, y, 6);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);

            // Enemy go left and right
            int limitRight;
            int limitLeft;

            if (position.Y == 900)
            {
                limitRight = 860;
                limitLeft = 430;
            }
            else
            {
                limitRight = 430;
                limitLeft = 60;
            }

            if (turn == false)
            {
                position.X += 3;
                if (position.X >= limitRight)
                    turn = true;
            }
            if (turn == true)
            {
                position.X -= 3;
                if (position.X == limitLeft)
                    turn = false;
            }            

            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        //public void Collision(Rectangle newRect, int xOffset, int yOffset)
        //{
        //    if (rectangle.TouchTopOf(newRect))
        //    {
        //        rectangle.Y = newRect.Y - rectangle.Height;
        //        velocity.Y = 0f;
        //    }
        //    if (rectangle.TouchLeftOf(newRect))
        //        position.X = newRect.X - rectangle.Width - 2; 
        //    if (rectangle.TouchRightOf(newRect))
        //        position.X = newRect.X + newRect.Width + 2;
        //    if (rectangle.TouchBottomOf(newRect))
        //        velocity.Y = 1f;

        //    if (position.X < 0) position.X = 0;
        //    if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
        //    if (position.Y < 0) velocity.Y = 1f;
        //    if (position.Y > xOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;

        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Black);
        }
    }
}
