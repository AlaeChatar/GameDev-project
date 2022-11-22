using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project
{
    internal class Player : IGameObject, IMovable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Velocity { get; set; }
        public IInputReader InputReader { get; set; }
        private MovementManager movementManager;

        public Player(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.InputReader = inputReader;
            Position = new Vector2(0, 400);
            Speed = new Vector2(2, 2);
            movementManager = new MovementManager();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, new Rectangle(0, 0, 30, 30), Color.Red);
        }

        public void Update(GameTime gameTime)
        {
            var direction = InputReader.ReadInput();
            direction *= Speed;
            Position += direction;

            movementManager.Move(this);
        }
    }
}
