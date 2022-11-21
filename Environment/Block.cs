using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDev_project.Environment
{
    internal class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, GraphicsDevice graphics)
        {
            BoundingBox = new Rectangle(x, y, 10, 10);
            Passable = false;
            Color = Color.Purple;
            Texture = new Texture2D(graphics, 1, 1);
            CollideWithEvent = new NoEvent();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, BoundingBox, Color);
        }

        public virtual void IsCollideWithEvent(Character collider)
        {
            CollideWithEvent.Execute();
        }
    }
}
