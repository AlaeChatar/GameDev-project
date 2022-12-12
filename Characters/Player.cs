using GameDev_project.Animations;
using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Velocity { get; set; }
        public IInputReader InputReader { get; set; }

        public Rectangle HitBox { get; set; }
        public bool IsDead { get; set; }
        public int HP { get; set; }
        public bool IsHit { get; set; }
        public float invulnerability;

        private MovementManager movementManager;
        //Animation animation;

        public Player(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            
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
            //hitBox
            spriteBatch.Draw(texture, Position, HitBox, Color.Blue);

            //player, hit ? rood : geel
            if (invulnerability <= 0)
                spriteBatch.Draw(texture, Position, new Rectangle(0, 0, 30, 30), Color.Yellow);
            else
            {
                spriteBatch.Draw(texture, Position, new Rectangle(0, 0, 30, 30), Color.Red);
                IsHit = false;
            }
        }

        public void Update(GameTime gameTime)
        {
            var direction = InputReader.ReadInput();
            direction *= Speed;
            Position += direction;

            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 31, 31);

            movementManager.Move(this);

            //invincible timer
            invulnerability -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (IsHit == true && invulnerability <= 0)
            {
                //voor hoelang is die invincible na een hit
                invulnerability = 0.5f;
                HP -= 1;
            }

            if (HP == 0)
                IsDead = true;
        }
    }
}
