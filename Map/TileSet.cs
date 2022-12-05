using GameDev_project.Gamescreens;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace GameDev_project.Map
{
    internal class TileSet : IGameObject
    {
        Texture2D texture;

        public List<Block> blocksFirstLevel = new List<Block>();
        public List<Block> blocksFinalLevel = new List<Block>();
        private List<Block> allBlocks = new List<Block>();

        public Vector2 position = new Vector2(0, 0);
        private double counter;

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

        public TileSet(int[,] level, List<Block> blocks, Texture2D texture)
        {
            this.texture = texture;

            for (int l = 0; l < level.GetLength(0); l++)
            {

                for (int c = 0; c < level.GetLength(1); c++)
                {
                    if (level[l, c] == 0)
                    {
                        blocks.Add(new Block(Block.BlockType.Sky, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Sky, new Vector2(c * 50, l * 50)));
                    }
                    else if (level[l, c] == 1)
                    {
                        blocks.Add(new Block(Block.BlockType.Floor1, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Floor2, new Vector2(c * 50, l * 50)));
                    }
                    else if (level[l, c] == 2)
                    {
                        blocks.Add(new Block(Block.BlockType.Floor2, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Floor2, new Vector2(c * 50, l * 50)));
                    }
                    else if (level[l, c] == 3)
                    {
                        blocks.Add(new Block(Block.BlockType.Lava, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Lava, new Vector2(c * 50, l * 50)));


                    }
                    else if (level[l, c] == 4)
                    {
                        blocks.Add(new Block(Block.BlockType.Lava, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Lava, new Vector2(c * 50, l * 50)));

                    }
                    else if (level[l, c] == 5)
                    {
                        blocks.Add(new Block(Block.BlockType.Grass, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Grass, new Vector2(c * 50, l * 50)));

                    }
                    else if (level[l, c] == 6)
                    {
                        blocks.Add(new Block(Block.BlockType.Grass, new Vector2(c * 50, l * 50)));
                        allBlocks.Add(new Block(Block.BlockType.Grass, new Vector2(c * 50, l * 50)));

                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, 0, 1000, 700), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)position.X + 1000, 0, 1000, 700), Color.White);

            if (ScreenManager.currentState == Gamestates.FirstLevel)
            {
                foreach (var block in blocksFirstLevel)
                {
                    if (block.block != Block.BlockType.Sky)
                    {
                        spriteBatch.Draw(texture, block.position, block.texture, Color.White);

                    }
                }
            }
            if (ScreenManager.currentState == Gamestates.FinalLevel)
            {
                foreach (var block in blocksFinalLevel)
                {
                    if (block.block != Block.BlockType.Sky)
                    {
                        spriteBatch.Draw(texture, block.position, block.texture, Color.White);

                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            counter += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (counter > 50d)
            {
                position.X -= 1;
                counter = 0;
            }
            if (position.X < -1000)
            {
                position.X = 0;
            }
        }
    }
}
