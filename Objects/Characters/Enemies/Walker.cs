using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Objects.Characters.Enemies.Movement;
using GameDev_project.Objects.Interfaces;
using GameDev_project.Objects.Characters.LifeSpan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Characters.Enemies
{
    internal class Walker : Enemy, IGameObject
    {
        public Walker(List<Texture2D> textures, Vector2 position)
        {
            this.textures = textures;
            Position = position;
            health = new Life(1);
            enemyBehavior = new TurnAround(position, turn);
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 6, 1);
            animation.GetFramesFromTextureProperties(textures[1].Width, textures[1].Height, 6, 1);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (enemyBehavior.Turn == false)
                spriteBatch.Draw(textures[0], new Vector2(Position.X, Position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
            if (enemyBehavior.Turn == true)
                spriteBatch.Draw(textures[1], new Vector2(Position.X, Position.Y - 10), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
