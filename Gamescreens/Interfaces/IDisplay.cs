using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens.Interfaces
{
    internal interface IDisplay
    {
        void PrintScreen(SpriteBatch spriteBatch);
        void RefreshScreen(GameTime gameTime);
    }
}
