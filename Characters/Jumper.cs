using GameDev_project.Collision;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Characters
{
    internal class Jumper : Enemy, IGameObject
    {
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position.X = value.X;
                position.Y = value.Y;
                position = value;
            }
        }

        public Jumper(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);

            Bounce();

            HitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Orange);
        }
    }
}
