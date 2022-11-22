using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreen
{
    internal class StartScreen : IGameObject
    {
        private Texture2D texture1;
        private Texture2D texture2;
        private Texture2D texture3;
        private Texture2D texture4;

        public StartScreen(Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.texture3 = texture3;
            this.texture4 = texture4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture1, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(texture2, new Rectangle(0, 0, 800, 200), Color.Red);
            spriteBatch.Draw(texture3, new Rectangle(100, 100, 500, 350), Color.Olive);
            spriteBatch.Draw(texture4, new Rectangle(220, 250, 325, 75), Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
