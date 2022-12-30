using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Map;
using GameDev_project.Objects.Characters;
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
        private List<Enemy> enemies;

        // Map
        TileSet tileSet;
        Rectangle checkpoint1 = new Rectangle((int)1919, (int)330, 30, 120);
        Rectangle checkpoint2 = new Rectangle((int)-29, (int)330, 30, 120);
        Rectangle goal = new Rectangle((int)30, (int)870, 30, 60);

        private Camera camera;
        private SpriteFont font;

        // Collision
        private EnemyCollision enemyCollision;
        private HeroCollision heroCollision;

        public Level(Texture2D backkground1, Texture2D background2, Texture2D background3, Texture2D background4, Texture2D background5, Texture2D texture, Hero hero, List<Enemy> enemies, TileSet tileSet, Camera camera, SpriteFont font)
        {
            this.background1 = backkground1;
            this.background2 = background2;
            this.background3 = background3;
            this.background4 = background4;
            this.background5 = background5;

            this.texture = texture;
            this.hero = hero;
            this.enemies = enemies;

            this.tileSet = tileSet;

            this.camera = camera;
            this.font = font;

            enemyCollision = new EnemyCollision();
            heroCollision = new HeroCollision();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background1, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background2, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background3, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background4, new Rectangle(0, 0, 1920, 1080), Color.Olive);
            spriteBatch.Draw(background5, new Rectangle(0, 0, 1920, 1080), Color.Olive);

            // Transition to other level
            spriteBatch.Draw(texture, checkpoint1, Color.Black);
            spriteBatch.Draw(texture, checkpoint2, Color.Black);

            foreach (Walker enemy in enemies.OfType<Walker>())
                enemy.Draw(spriteBatch);
            foreach (Jumper enemy in enemies.OfType<Jumper>())
                enemy.Draw(spriteBatch);
            tileSet.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            
            // Hero position
            spriteBatch.DrawString(font, $"{Math.Round(hero.position.X)} : {string.Format("{0:F0}", Math.Round(hero.position.Y))}", new Vector2(hero.position.X - 30, hero.position.Y - 60), Color.White);

            if (currentState == Gamestates.Level2)
                spriteBatch.Draw(texture, goal, Color.Blue);
        }

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            enemyCollision.TouchEnemy(hero, enemies, gameTime);

            // Map collision
            foreach (CollisionBlocks block in tileSet.CollisionBlocks)
            {
                heroCollision.Collide(hero, block.Rectangle, tileSet.Width, tileSet.Height);
                camera.Update(hero.position, tileSet.Width, tileSet.Height);
            }

            if (hero.hitBox.Intersects(checkpoint1) == true)
                currentState = Gamestates.Level2;
            if (hero.hitBox.Intersects(checkpoint2) == true)
                currentState = Gamestates.Level1;
            if (hero.hitBox.Intersects(goal) == true)
                currentState = Gamestates.Goal;
        }
    }
}
