using GameDev_project.Interfaces;
using GameDev_project.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens
{
    internal class StartScreen : IGameObject
    {
        private Texture2D background;
        private Texture2D dinoHead;
        private Texture2D woodenPlank;
        private SpriteFont titleFont;
        private SpriteFont pressEnterFont;


        public StartScreen(Texture2D background,  Texture2D dinoHead, Texture2D woodenPlank, SpriteFont titleFont, SpriteFont pressEnterFont)
        {
            this.background = background;
            this.dinoHead = dinoHead;
            this.woodenPlank = woodenPlank;
            this.titleFont = titleFont;
            this.pressEnterFont = pressEnterFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(woodenPlank, new Rectangle(0, 0, 800, 180), Color.Brown);
            spriteBatch.DrawString(titleFont, "Jurassic Jungle", new Vector2(60, 60), Color.DarkRed);
            spriteBatch.Draw(dinoHead, new Rectangle(100, 100, 500, 350), Color.Olive);
            spriteBatch.DrawString(pressEnterFont, "PRESS ENTER", new Vector2(325, 250), Color.White);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
