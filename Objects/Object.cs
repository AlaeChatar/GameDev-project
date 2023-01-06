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
    abstract class Object
    {
        protected List<Texture2D> textures;
        private Vector2 position;
        public virtual Vector2 Position 
        { 
            get { return position; }
            set { position = value; }
        }

        protected Rectangle hitBox;
        public Rectangle HitBox 
        { 
            get { return hitBox; } 
            set { hitBox = value; }
        }

        public Life health;

        public Animation animation;
    }
}
