using GameDev_project.Gamescreens.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GameDev_project.Gamescreens.Screens
{
    internal class GameOver : Screen, IDisplay
    {
        public GameOver(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            this.font = font;
        }

        public void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(80, 0, 800, 400), Color.Olive);
            if (timer <= .5)
                spriteBatch.DrawString(font, "Press R to try again", new Vector2(960 / 2 - font.MeasureString("Press R to try again").Length() / 2, 400), Color.Transparent);
            else
                spriteBatch.DrawString(font, "Press R to try again", new Vector2(960 / 2 - font.MeasureString("Press R to try again").Length() / 2, 400), Color.White);
        }

        public void RefreshScreen(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
                timer = 1f;
        }
    }
}
