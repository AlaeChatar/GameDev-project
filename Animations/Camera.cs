using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Animations
{
    public class Camera
    {
        private Matrix transform;
        public Matrix Transform { get { return transform; } }

        private Vector2 centre;
        private Viewport viewport;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < viewport.Width / 4)
                centre.X = viewport.Width / 4;
            else if (position.X > xOffset - (viewport.Width / 4))
                centre.X = xOffset - (viewport.Width / 4);
            else
                centre.X = position.X;

            if (position.Y < viewport.Height / 4)
                centre.Y = viewport.Height / 4;
            else if (position.Y > yOffset - (viewport.Height / 4))
                centre.Y = yOffset - (viewport.Height / 4);
            else
                centre.Y = position.Y;


            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewport.Width / 2),
                                                             -centre.Y + (viewport.Height / 2), 0));
        }
    }
}
