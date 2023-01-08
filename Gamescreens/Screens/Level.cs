using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Gamescreens.Interfaces;
using GameDev_project.Map;
using GameDev_project.Objects;
using GameDev_project.Objects.Characters;
using GameDev_project.Objects.Characters.Enemies;
using GameDev_project.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Gamescreens.Screens
{
    internal class Level : Screen, IDisplay
    {
        private int counterEggs;
        public int CounterEggs 
        { 
            get { return counterEggs; } 
            set { counterEggs = value; }
        }

        // Objects
        private Hero hero;
        private List<Enemy> enemies;
        private List<Lava> lava;
        private List<Item> eggs;
        private Item escape;

        // Map
        TileSet tileSet;
        Rectangle checkpoint1 = new Rectangle(1919, 330, 30, 120);
        Rectangle checkpoint2 = new Rectangle(-29, 330, 30, 120);

        private Camera camera;

        // Collision
        private EnemyCollision enemyCollision;
        private HeroCollision heroCollision;

        public Level(Texture2D texture, Hero hero, List<Enemy> enemies, List<Lava> lava, List<Item> eggs, Item escape, TileSet tileSet, Camera camera)
        {
            this.texture = texture;
            this.hero = hero;
            this.enemies = enemies;
            this.lava = lava;
            this.eggs = eggs;
            this.escape = escape;
            this.tileSet = tileSet;

            this.camera = camera;

            enemyCollision = new EnemyCollision();
            heroCollision = new HeroCollision();
        }

        public void PrintScreen(SpriteBatch spriteBatch)
        {
            foreach (Lava lava in lava)
                lava.Draw(spriteBatch);

            foreach (Item egg in eggs)
            {
                if (egg.Collected == false)
                    egg.Draw(spriteBatch);
            }

            spriteBatch.Draw(texture, checkpoint1, Color.Black);
            spriteBatch.Draw(texture, checkpoint2, Color.Black);

            foreach (Walker enemy in enemies.OfType<Walker>())
                enemy.Draw(spriteBatch);
            foreach (Jumper enemy in enemies.OfType<Jumper>())
                enemy.Draw(spriteBatch);
            tileSet.Draw(spriteBatch);
            hero.Draw(spriteBatch);

            if (CurrentState == GameStates.Level2)
                escape.Draw(spriteBatch);
        }

        public void RefreshScreen(GameTime gameTime)
        {
            hero.Update(gameTime);
            enemyCollision.TouchEnemy(hero, enemies, gameTime);

            foreach (Walker enemy in enemies.OfType<Walker>())
                enemy.Update(gameTime);
            foreach (Jumper enemy in enemies.OfType<Jumper>())
                enemy.Update(gameTime);

            foreach (Item egg in eggs)
            {
                egg.Update(gameTime);
                if (hero.HitBox.Intersects(egg.HitBox))
                {
                    Sfx.Collect();
                    egg.Collected = true;
                    counterEggs++;
                    egg.HitBox = new Rectangle(2000, 2000, 0, 0);
                }
            }

            escape.Update(gameTime);

            // Map collision
            foreach (CollisionBlocks block in tileSet.CollisionBlocks)
            {
                heroCollision.Collide(hero, block.Rectangle, tileSet.Width, tileSet.Height);
                camera.Update(hero.Position, tileSet.Width, tileSet.Height);
            }

            foreach (Lava lava in lava)
            {
                if (hero.HitBox.Intersects(lava.HitBox))
                    hero.Health.IsHit = true;
            }

            if (hero.HitBox.Intersects(checkpoint1))
                CurrentState = GameStates.Level2;
            if (hero.HitBox.Intersects(checkpoint2))
                CurrentState = GameStates.Level1;
            if (hero.HitBox.Intersects(escape.HitBox))
                CurrentState = GameStates.Goal;
        }
    }
}
