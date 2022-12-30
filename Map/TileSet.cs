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
        private List<CollisionBlocks> collisionBlocks = new List<CollisionBlocks>();
        public List<CollisionBlocks> CollisionBlocks
        { 
            get { return collisionBlocks; } 
        }

        private int width, height;
        public int Width
        { 
            get { return width; } 
        }
        public int Height
        {
            get { return height; }
        }

        public TileSet() {}

        public void Create(int[,] tileSet, int size)
        {
            for (int i = 0; i < tileSet.GetLength(1); i++)
                for (int j = 0; j < tileSet.GetLength(0); j++)
                {
                    int number = tileSet[j, i];

                    if (number > 0)
                        collisionBlocks.Add(new CollisionBlocks(number, new Rectangle(i * size, j * size, size, size)));

                    width = (i + 1) * size;
                    height= (j + 1) * size;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionBlocks block in collisionBlocks)
                block.Draw(spriteBatch);
        }
    }
}
