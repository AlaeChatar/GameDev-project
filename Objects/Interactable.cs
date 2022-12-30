using GameDev_project.Objects.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Objects
{
    internal class Interactable : Object, IGameObject
    {
        public Interactable(List<Texture2D> textures, Vector2 position)
        {
            this.textures = textures;
            this.position = position;
            //animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 4, 1);
        }

        public void Update(GameTime gameTime)
        {
            hitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(textures[0], new Vector2(position.X, position.Y - 20), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
