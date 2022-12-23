using GameDev_project.Characters;
using GameDev_project.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Gamescreens
{
    internal class Level
    {
        // Background
        private Texture2D background1;
        private Texture2D background2;
        private Texture2D background3;
        private Texture2D background4;
        private Texture2D background5;

        // Characters
        private Texture2D texture;
        private Hero hero;

        // Map
        TileSet tileSet;
        Rectangle checkpoint1 = new Rectangle((int)1919, (int)390, 30, 120);
        Rectangle checkpoint2 = new Rectangle((int)-29, (int)330, 30, 120);

        private SpriteFont font;


        public Level(Texture2D backkground1, Texture2D background2, Texture2D background3, Texture2D background4, Texture2D background5, Texture2D texture, Hero hero, TileSet tileSet, SpriteFont font)
        {
            this.background1 = backkground1;
            this.background2 = background2;
            this.background3 = background3;
            this.background4 = background4;
            this.background5 = background5;

            this.texture = texture;
            this.hero = hero;

            this.tileSet = tileSet;

            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background1, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background2, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background3, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background4, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background5, new Rectangle(0, 0, 1920, 1080), Color.Olive);

            // Transition to other level
            spriteBatch.Draw(texture, checkpoint1, Color.Red);
            spriteBatch.Draw(texture, checkpoint2, Color.Red);

            tileSet.Draw(spriteBatch);
            hero.Draw(spriteBatch);

            // Hero position
            spriteBatch.DrawString(font, $"{hero.Position.X} : {string.Format("{0:F0}", hero.Position.Y)}", new Vector2(50, 0), Color.Yellow);
        }

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);

            foreach (CollisionBlocks block in tileSet.CollisionBlocks)
                hero.Collision(block.Rectangle, tileSet.Width, tileSet.Height);

            if (hero.HitBox.Intersects(checkpoint1) == true || Keyboard.GetState().IsKeyDown(Keys.L))
                currentState = Gamestates.Level2;
            if (hero.HitBox.Intersects(checkpoint2) == true || Keyboard.GetState().IsKeyDown(Keys.L))
                currentState = Gamestates.Level1;

            //if (player.HitBox.Intersects(checkpoint1))
            //    player.IsHit = true;
        }
    }
}
