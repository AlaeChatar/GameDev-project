using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GameDev_project.Gamescreens
{
    internal class GameOver : IGameObject
    {
        Texture2D endScreen;

        public GameOver(Texture2D texture)
        {
            this.endScreen = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(endScreen, new Rectangle(0, 0, 800, 500), Color.Olive);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
