using GameDev_project.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens.Screens
{
    internal class Start : Screen
    {
        private Texture2D background;
        private Texture2D border;
        private Texture2D dinoHead;
        private Texture2D woodenPlank;
        private SpriteFont titleFont;
        private SpriteFont pressEnterFont;

        public Start(Texture2D background, Texture2D border, Texture2D dinoHead, Texture2D woodenPlank, SpriteFont titleFont, SpriteFont pressEnterFont)
        {
            this.background = background;
            this.border = border;
            this.dinoHead = dinoHead;
            this.woodenPlank = woodenPlank;
            this.titleFont = titleFont;
            this.pressEnterFont = pressEnterFont;
        }

        public override void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 960, 540), Color.Olive);
            spriteBatch.Draw(border, new Rectangle(0, 0, 960, 540), Color.Black);
            spriteBatch.Draw(woodenPlank, new Rectangle(0, 0, 960, 150), Color.Brown);
            spriteBatch.DrawString(titleFont, "Jurassic Jungle", new Vector2(90, 45), Color.DarkRed);
            spriteBatch.Draw(dinoHead, new Rectangle(50, 60, 750, 510), Color.Olive);
            spriteBatch.DrawString(pressEnterFont, "PRESS ENTER", new Vector2(380, 270), Color.White);
        }

        public override void RefreshScreen(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
