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
    internal class Lava : Object
    {
        private Texture2D texture;
        private int width;
        private int height;

        public Lava(Texture2D texture, Vector2 position, int width, int height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
            hitBox = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.Transparent);
        }
    }
}
