using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Environment
{
    internal class SlimeBlock : Block
    {
        public SlimeBlock(int x, int y, GraphicsDevice graphics) : base(x, y, graphics)
        {
            BoundingBox = new Rectangle(x, y, 10, 10);
            Passable = true;
            Color = Color.GreenYellow;
            Texture = new Texture2D(graphics, 1, 1);
            CollideWithEvent = new SlowEvent();
        }
    }
}
