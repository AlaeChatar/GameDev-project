using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Map
{
    internal class CollisionBlocks : Block
    {
        public CollisionBlocks(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("Block" + i);
            this.Rectangle= newRectangle;
        }
    }
}
