using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Map
{
    internal class TileSet
    {
        List<Block> blocks;

        public TileSet(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block block in blocks)
                block.Draw(spriteBatch);
        }
    }
}
