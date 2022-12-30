using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Objects.Interfaces;
using GameDev_project.Objects.LifeSpan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters
{
    internal class Walker : Enemy, IGameObject
    {
        public Walker(List<Texture2D> textures, Vector2 position)
        {
            this.textures = textures;
            this.position = position;
            health = new Life(1);
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 6, 1);
        }

        public void Update(GameTime gameTime)
        {
            Turn();
            hitBox = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (turn == false)
                spriteBatch.Draw(textures[0], new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
            if (turn == true)
                spriteBatch.Draw(textures[1], new Vector2(position.X, position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
