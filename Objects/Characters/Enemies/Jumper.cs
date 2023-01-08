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
    internal class Jumper : Enemy, IGameObject
    {
        public Jumper(List<Texture2D> textures, Vector2 position)
        {
            this.textures = textures;
            Position = position;
            enemyBehavior = new Jump(position);
            health = new Life(999);
            animation = new Animation();
            animation.GetFramesFromTextureProperties(textures[0].Width, textures[0].Height, 5, 1);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textures[0], Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
