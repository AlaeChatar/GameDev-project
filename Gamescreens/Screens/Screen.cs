﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens.Screens
{
    abstract class Screen
    {
        public abstract void PrintScreen(SpriteBatch spriteBatch);
        public abstract void RefreshScreen(GameTime gameTime);
    }
}
