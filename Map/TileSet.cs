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
    internal class TileSet : IGameObject
    {
        public List<Block> BlocksFirstLevel = new List<Block>();
        public List<Block> BlocksFinalLevel = new List<Block>();
        int[,] level1 = new int[,]
        {
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0}
        };

        int[,] level2 = new int[,]
        {
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0},
            {0, 0},
            {1, 0}
        };

        public TileSet()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
