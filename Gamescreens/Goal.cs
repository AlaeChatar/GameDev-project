using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens
{
    internal class Goal
    {
        Texture2D endScreen;

        public Goal(Texture2D texture)
        {
            this.endScreen = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(endScreen, new Rectangle(0, 0, 960, 540), Color.Olive);
        }
    }
}
