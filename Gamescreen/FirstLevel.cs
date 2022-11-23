using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDev_project.Interfaces;

namespace GameDev_project.Gamescreen
{
    internal class FirstLevel : IGameObject
    {
        private Texture2D firstLevelBackground1;
        private Texture2D firstLevelBackground2;
        private Texture2D firstLevelBackground3;
        private Texture2D firstLevelBackground4;
        private Texture2D firstLevelBackground5;


        public FirstLevel(Texture2D firstLevelBackground1, Texture2D firstLevelBackground2, Texture2D firstLevelBackground3, Texture2D firstLevelBackground4, Texture2D firstLevelBackground5)
        {
            this.firstLevelBackground1 = firstLevelBackground1;
            this.firstLevelBackground2 = firstLevelBackground2;
            this.firstLevelBackground3 = firstLevelBackground3;
            this.firstLevelBackground4 = firstLevelBackground4;
            this.firstLevelBackground5 = firstLevelBackground5;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(firstLevelBackground1, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(firstLevelBackground2, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(firstLevelBackground3, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(firstLevelBackground4, new Rectangle(0, 0, 800, 500), Color.Olive);
            spriteBatch.Draw(firstLevelBackground5, new Rectangle(0, 0, 800, 500), Color.Olive);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
