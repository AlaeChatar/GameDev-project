using GameDev_project.Characters;
using GameDev_project.Interfaces;
using GameDev_project.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        TileSet tileSet;

        Rectangle obstakel;

        public ScreenManager(Hero hero, Player player, Enemy enemy, Boss boss, Texture2D blokTexture, StartScreen startScreen, FirstLevel firstLevel, FinalLevel finalLevel, Goal goal, GameOver gameOver, TileSet tileSet)
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
            this.tileSet = tileSet;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
  
            if (currentState == Gamestates.Start)
                startScreen.Draw(spriteBatch);

            if (currentState == Gamestates.FirstLevel)
            {
                
                firstLevel.Draw(spriteBatch);
                //player.Draw(spriteBatch);
                hero.Draw(spriteBatch);
                tileSet.Draw(spriteBatch);
            }

            if (currentState == Gamestates.FinalLevel)
            {
                finalLevel.Draw(spriteBatch);
                player.Draw(spriteBatch);
                tileSet.Draw(spriteBatch);
            }

            if (currentState == Gamestates.Goal)
            {
                goal.Draw(spriteBatch);
                player.Draw(spriteBatch);
            }

            if (currentState == Gamestates.GameOver)
                gameOver.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            foreach (CollisionBlocks block in tileSet.CollisionBlocks)
            {
                hero.Collision(block.Rectangle, tileSet.Width, tileSet.Height);
            }
            player.Update(gameTime);

            if (player.HitBox.Intersects(obstakel))
                player.IsHit = true;


            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start)
                currentState = Gamestates.FirstLevel;
            //if (true)
            //    currentState = Gamestates.FinalLevel;
            //if (boss.IsDead == true && currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.Goal;
            if (player.IsDead == true && currentState == Gamestates.FirstLevel || currentState == Gamestates.FinalLevel)
                currentState = Gamestates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == Gamestates.GameOver)
                currentState = Gamestates.FirstLevel;
        }
    }
}
