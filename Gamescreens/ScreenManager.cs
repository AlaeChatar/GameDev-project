using GameDev_project.Characters;
using GameDev_project.Interfaces;
using GameDev_project.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Game1;

namespace GameDev_project.Gamescreens
{
    internal class ScreenManager
    {
        public enum Gamestates { Start, FirstLevel, FinalLevel, GameOver, Goal }
        public static Gamestates currentState = Gamestates.Start;

        //Screens
        StartScreen startScreen;
        FirstLevel firstLevel;
        FinalLevel finalLevel;
        GameOver gameOver;
        Goal goal;

        //Characters
        Player player;
        Enemy enemy;
        Boss boss;
        Hero hero;
        Texture2D blokTexture;

        //Map
        TileSet tileSet1;
        TileSet tileSet2;

        Rectangle checkpoint1 = new Rectangle((int)1919, (int)390, 30, 120);

        public ScreenManager(Hero hero, Player player, Enemy enemy, Boss boss, Texture2D blokTexture, StartScreen startScreen, FirstLevel firstLevel, FinalLevel finalLevel, Goal goal, GameOver gameOver, TileSet tileSet, TileSet tileSet2)
        {
            this.hero = hero;
            this.player = player;
            this.enemy = enemy;
            this.boss = boss;
            this.blokTexture = blokTexture;
            this.startScreen = startScreen;
            this.firstLevel = firstLevel;
            this.finalLevel = finalLevel;
            this.goal = goal;
            this.gameOver = gameOver;
            this.tileSet1 = tileSet;
            this.tileSet2 = tileSet2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            

            switch (currentState)
            {   
                case Gamestates.Start:
                    startScreen.Draw(spriteBatch);
                    break;
                case Gamestates.FirstLevel:
                    firstLevel.Draw(spriteBatch);
                    spriteBatch.Draw(blokTexture, checkpoint1, Color.Red);
                    tileSet1.Draw(spriteBatch);
                    hero.Draw(spriteBatch);
                    break;
                case Gamestates.FinalLevel:
                    finalLevel.Draw(spriteBatch);
                    tileSet2.Draw(spriteBatch);
                    hero.Position = new Vector2(65, 400);
                    hero.Draw(spriteBatch);
                    break;
                case Gamestates.GameOver:
                    gameOver.Draw(spriteBatch);
                    break;
                case Gamestates.Goal:
                    goal.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            
            // Map collision
            if (currentState == Gamestates.FirstLevel)
            {
                hero.Update(gameTime);
                foreach (CollisionBlocks block in tileSet1.CollisionBlocks)
                    hero.Collision(block.Rectangle, tileSet1.Width, tileSet1.Height);
            }
            if (currentState == Gamestates.FinalLevel)
            {
                hero.Update(gameTime);
                foreach (CollisionBlocks block in tileSet2.CollisionBlocks)
                    hero.Collision(block.Rectangle, tileSet2.Width, tileSet2.Height);
            }            

            //if (player.HitBox.Intersects(checkpoint1))
            //    player.IsHit = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start)
                currentState = Gamestates.FirstLevel;
            if (hero.HitBox.Intersects(checkpoint1) == true || Keyboard.GetState().IsKeyDown(Keys.L))
                currentState = Gamestates.FinalLevel;
            //if (boss.IsDead == true && currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.Goal;
            //if (player.IsDead == true && currentState == Gamestates.FirstLevel || currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == Gamestates.GameOver)
                currentState = Gamestates.FirstLevel;
        }
    }
}
