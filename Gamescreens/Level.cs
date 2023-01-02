﻿using GameDev_project.Animations;
using GameDev_project.Collision;
using GameDev_project.Map;
using GameDev_project.Objects;
using GameDev_project.Objects.Characters;
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

namespace GameDev_project.Gamescreens
{
    internal class Level
    {
        // Objects
        private Texture2D texture;
        private Hero hero;
        private List<Enemy> enemies;
        private List<Lava> lava;
        private List<Item> eggs;
        private Item escape;

        // Map
        TileSet tileSet;
        Rectangle checkpoint1 = new Rectangle((int)1919, (int)330, 30, 120);
        Rectangle checkpoint2 = new Rectangle((int)-29, (int)330, 30, 120);

        private Camera camera;
        private SpriteFont font;

        // Collision
        private EnemyCollision enemyCollision;
        private HeroCollision heroCollision;

        public Level(Texture2D texture, Hero hero, List<Enemy> enemies, List<Lava> lava, List<Item> eggs, Item escape, TileSet tileSet, Camera camera, SpriteFont font)
        {
            this.texture = texture;
            this.hero = hero;
            this.enemies = enemies;
            this.lava = lava;
            this.eggs = eggs;
            this.escape = escape;
            this.tileSet = tileSet;

            this.camera = camera;
            this.font = font;

            enemyCollision = new EnemyCollision();
            heroCollision = new HeroCollision();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Lava lava in lava)
                lava.Draw(spriteBatch);

            foreach (Item egg in eggs)
            {
                if (egg.collected == false)
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
            
            // Hero position
            spriteBatch.DrawString(font, $"{Math.Round(hero.position.X)} : {string.Format("{0:F0}", Math.Round(hero.position.Y))}", new Vector2(hero.position.X - 30, hero.position.Y - 60), Color.White);

            if (currentState == Gamestates.Level2)
                escape.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            enemyCollision.TouchEnemy(hero, enemies, gameTime);

            foreach (Item egg in eggs)
            {
                egg.Update(gameTime);
                if (hero.hitBox.Intersects(egg.hitBox))
                    egg.collected = true;
            }

            escape.Update(gameTime);

            // Map collision
            foreach (CollisionBlocks block in tileSet.CollisionBlocks)
            {
                heroCollision.Collide(hero, block.Rectangle, tileSet.Width, tileSet.Height);
                camera.Update(hero.position, tileSet.Width, tileSet.Height);
            }

            foreach (Lava lava in lava)
            {
                if (hero.hitBox.Intersects(lava.hitBox))
                    hero.health.IsHit = true;
            }

            if (hero.hitBox.Intersects(checkpoint1))
                currentState = Gamestates.Level2;
            if (hero.hitBox.Intersects(checkpoint2))
                currentState = Gamestates.Level1;
            if (hero.hitBox.Intersects(escape.hitBox))
                currentState = Gamestates.Goal;
        }
    }
}
