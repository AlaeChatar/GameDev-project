using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Characters
{
    internal class Boss : IGameObject, IMovable
    {
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IInputReader InputReader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
