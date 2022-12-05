using Microsoft.Xna.Framework;
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
        public enum BlockType { Sky, Floor1, Floor2, Lava, Grass}
        public BlockType block { get; set; }
        public Rectangle texture;
        public Vector2 position;

        public Block(BlockType blockType, Vector2 rectIn)
        {
            if (blockType == BlockType.Sky)
                block = BlockType.Sky;
            if (blockType == BlockType.Floor1)
                block = BlockType.Floor1;
            if (blockType == BlockType.Floor2)
                block = BlockType.Floor2;
            if (blockType == BlockType.Lava)
                block = BlockType.Lava;
            if (blockType == BlockType.Grass)
                block = BlockType.Grass;
        }
    }
}
