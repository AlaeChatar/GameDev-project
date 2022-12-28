using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Movement
{
    internal class MovementManager
    {
        public bool hasJumped;

        public void Move(IMovable movable)
        {
            movable.Position += movable.Velocity;

            Vector2 direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            Vector2 afstand = direction * movable.Velocity;
            movable.Position += afstand;

            if (direction.Y < 0 && hasJumped == false)
            {
                movable.Position -= new Vector2(0, 5f);
                movable.Velocity = new Vector2(0, -9f);
                hasJumped = true;
            }

            if (movable.Velocity.Y < 10)
                movable.Velocity += new Vector2(0, 0.4f);
        }

    }
}
