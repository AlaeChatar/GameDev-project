using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens
{
    internal class FinalLevel
    {
        private Texture2D background1;
        private Texture2D background2;
        private Texture2D background3;
        private Texture2D background4;
        private Texture2D background5;


        public FinalLevel(Texture2D backkground1, Texture2D background2, Texture2D background3, Texture2D background4, Texture2D background5)
        {
            this.background1 = backkground1;
            this.background2 = background2;
            this.background3 = background3;
            this.background4 = background4;
            this.background5 = background5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background1, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background2, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background3, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background4, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background5, new Rectangle(0, 0, 1920, 1080), Color.Olive);
        }
    }
}
