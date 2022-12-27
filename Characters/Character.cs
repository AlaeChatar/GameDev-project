using GameDev_project.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Characters
{
    internal abstract class Character
    {
        public List<Texture2D> textures;
        public Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle hitBox;
        public Rectangle HitBox
        { 
            get { return hitBox; }
            set { hitBox = value; } 
        }

        public Animation animation;
    }
}
