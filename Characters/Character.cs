using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Characters
{
    internal class Character
    {
        public Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;
        public Rectangle HitBox { get; set; }
    }
}
