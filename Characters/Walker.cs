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
    internal class Walker : Enemy, IGameObject
    {
        public Walker(Texture2D textureRight, Texture2D textureLeft, Vector2 position)
        {
            this.textureRight = textureRight;
            this.textureLeft = textureLeft;
            this.position = position;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textureRight.Width, textureRight.Height, 6, 1);
        }

        public void Update(GameTime gameTime)
        {
            Turn();            
            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (turn == false)
                spriteBatch.Draw(textureRight, new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
            if (turn == true)
                spriteBatch.Draw(textureLeft, new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
