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
        public bool jump = false;
        public float currentHeight;

        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
            }

            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;
            movable.Position = futurePosition;
            movable.Position += distance;

            movable.Position += movable.Velocity;
            if (direction.Y < 0 && jump == false)
            {
                currentHeight = movable.Position.Y;
                movable.Position -= new Vector2(0,-10f);
                movable.Velocity -= new Vector2(0, -5f);
                jump = true;
            }

            if (jump == true)
            {
                float gravity = 1;
                movable.Velocity += new Vector2(0, 0.15f * gravity);
            }

            if (movable.Position.Y >= currentHeight)
                movable.Velocity = Vector2.Zero;
        } 
    }
}
