using GameDev_project.Animations;
using GameDev_project.Objects.LifeSpan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Objects
{
    internal abstract class Object
    {
        public List<Texture2D> textures;
        public Vector2 position;
        public Rectangle hitBox;
        public Life health;

        public Animation animation;
    }
}
