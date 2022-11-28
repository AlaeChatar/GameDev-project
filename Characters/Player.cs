using GameDev_project.Animations;
using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Characters
{
    internal class Player : IGameObject, IMovable, IHp
    {
        private Texture2D texture;
        public Rectangle HitBox { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Velocity { get; set; }
        public IInputReader InputReader { get; set; }

        public bool IsDead { get; set; }
        public int HP { get; set; }
        public bool IsHit { get; set; }

        private MovementManager movementManager;
        //Animation animation;

        public Player(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            HitBox = new Rectangle(0, 0, texture.Width, texture.Height);
            
            InputReader = inputReader;
            Position = new Vector2(0, 400);
            Speed = new Vector2(2, 2);

            HP = 3;
            IsDead = false;

            movementManager = new MovementManager();
            //animation.GetFramesFromTextureProperties(texture.Width, y, 6);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsHit != true)
                spriteBatch.Draw(texture, Position, new Rectangle(0, 0, 30, 30), Color.Yellow);
            else
                spriteBatch.Draw(texture, Position, new Rectangle(0, 0, 30, 30), Color.Red);
        }

        public void Update(GameTime gameTime)
        {
            var direction = InputReader.ReadInput();
            direction *= Speed;
            Position += direction;

            movementManager.Move(this);

            if (IsHit == true)
                HP--;
            if (HP == 0)
                IsDead = true;
        }
    }
}
