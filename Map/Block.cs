using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Map
{
    internal class Block
    {
        private Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;


        public Block(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Brown);
        }
    }
}
