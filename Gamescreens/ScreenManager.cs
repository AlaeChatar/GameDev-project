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

        Rectangle obstakel = new Rectangle((int)1905, (int)390, 30, 120);

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
                    //player.Draw(spriteBatch);
                    spriteBatch.Draw(blokTexture, obstakel, Color.Red);
                    hero.Draw(spriteBatch);
                    tileSet1.Draw(spriteBatch);
                    break;
                case Gamestates.FinalLevel:
                    finalLevel.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    tileSet2.Draw(spriteBatch);
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
            hero.Update(gameTime);
            foreach (CollisionBlocks block in tileSet1.CollisionBlocks)
            {
                hero.Collision(block.Rectangle, tileSet1.Width, tileSet1.Height);
            }
            player.Update(gameTime);

            if (player.HitBox.Intersects(obstakel))
                player.IsHit = true;


            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start)
                currentState = Gamestates.FirstLevel;
            if (hero.HitBox.Intersects(obstakel) == true)
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
