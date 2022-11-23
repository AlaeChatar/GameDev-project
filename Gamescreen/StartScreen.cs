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
        private SpriteFont titleFont;
        private SpriteFont pressEnterFont;


        public StartScreen(Texture2D texture1,  Texture2D texture2, SpriteFont titleFont, SpriteFont pressEnterFont)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.titleFont = titleFont;
            this.pressEnterFont = pressEnterFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture1, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.DrawString(titleFont, "Jurassic Jungle", new Vector2(0, 10), Color.DarkRed);
            spriteBatch.Draw(texture2, new Rectangle(100, 100, 500, 350), Color.Olive);
            spriteBatch.DrawString(pressEnterFont, "PRESS ENTER", new Vector2(325, 250), Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
