using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        protected Texture2D texture;
        private Rectangle rectangle;
        public Rectangle Rectangle 
        { 
            get { return Rectangle; } 
            set { Rectangle = value; } 
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Brown);
        }
    }
}
