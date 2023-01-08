using GameDev_project.Animations;
using GameDev_project.Gamescreens.Interfaces;
using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens.Screens
{
    internal class Start : Screen, IDisplay
    {
        private Texture2D border;
        private Texture2D dinoHead;
        private Texture2D woodenPlank;
        private SpriteFont titleFont;

        public Start(Texture2D background, Texture2D border, Texture2D dinoHead, Texture2D woodenPlank, SpriteFont titleFont, SpriteFont font)
        {
            this.texture = background;
            this.border = border;
            this.dinoHead = dinoHead;
            this.woodenPlank = woodenPlank;
            this.titleFont = titleFont;
            this.font = font;
        }

        public void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, 960, 540), Color.Olive);
            spriteBatch.Draw(border, new Rectangle(0, 0, 960, 540), Color.Black);
            spriteBatch.Draw(woodenPlank, new Rectangle(0, 0, 960, 150), Color.Brown);
            spriteBatch.DrawString(titleFont, "Jurassic Jungle", new Vector2(90, 45), Color.DarkRed);
            spriteBatch.Draw(dinoHead, new Rectangle(50, 60, 750, 510), Color.Olive);
            if (timer <= .5)
                spriteBatch.DrawString(font, "PRESS ENTER", new Vector2(380, 270), Color.Transparent);
            else
                spriteBatch.DrawString(font, "PRESS ENTER", new Vector2(380, 270), Color.White); 
        }

        public void RefreshScreen(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
                timer = 1f;
        }
    }
}
