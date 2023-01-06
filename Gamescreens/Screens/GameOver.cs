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
    internal class GameOver : Screen
    {
        Texture2D endScreen;

        public GameOver(Texture2D texture)
        {
            endScreen = texture;
        }

        public override void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(endScreen, new Rectangle(0, 0, 960, 540), Color.Olive);
        }

        public override void RefreshScreen(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
