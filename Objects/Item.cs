using GameDev_project.Animations;
using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects
{
    internal class Item : Object, IGameObject
    {
        private Texture2D texture;
        private int numberOfFrames;
        private int numberOfRows;
        public bool collected;

        public Item(Texture2D texture, Vector2 position, int numberOfFrames, int numberOfRows)
        {
            this.texture = texture;
            this.position = position;
            this.numberOfFrames = numberOfFrames;
            this.numberOfRows = numberOfRows;
            collected = false;

            hitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation= new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, numberOfFrames, numberOfRows);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
