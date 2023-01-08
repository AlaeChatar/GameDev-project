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
        public GameOver(Texture2D texture)
        {
            this.texture = texture;
        }

        public void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(0, 0, 960, 540), Color.Olive);
        }

        public void RefreshScreen(GameTime gameTime)
        {
            // Extra: hero death animation
        }
    }
}
