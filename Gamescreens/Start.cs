using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens
{
    internal class Start
    {
        private Texture2D background;
        private Texture2D dinoHead;
        private Texture2D woodenPlank;
        private SpriteFont titleFont;
        private SpriteFont pressEnterFont;


        public Start(Texture2D background,  Texture2D dinoHead, Texture2D woodenPlank, SpriteFont titleFont, SpriteFont pressEnterFont)
        {
            this.background = background;
            this.dinoHead = dinoHead;
            this.woodenPlank = woodenPlank;
            this.titleFont = titleFont;
            this.pressEnterFont = pressEnterFont;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(woodenPlank, new Rectangle(0, 0, 1920, 360), Color.Brown);
            spriteBatch.DrawString(titleFont, "Jurassic Jungle", new Vector2(120, 120), Color.DarkRed);
            spriteBatch.Draw(dinoHead, new Rectangle(100, 100, 1500, 1050), Color.Olive);
            spriteBatch.DrawString(pressEnterFont, "PRESS ENTER", new Vector2(775, 600), Color.White);
        }
    }
}
