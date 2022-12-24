using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Characters
{
    internal class Enemy
    {
        public Rectangle HitBox { get; set; }

        public void Draw(SpriteBatch spriteBatch) {}
        public void Update(GameTime gameTime) {}
    }
}
