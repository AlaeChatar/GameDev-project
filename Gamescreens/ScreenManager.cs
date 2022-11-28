using GameDev_project.Characters;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Game1;

namespace GameDev_project.Gamescreens
{
    internal class ScreenManager : IGameObject
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
        Texture2D blokTexture;

        Rectangle obstakel;

        public ScreenManager(Player player, Enemy enemy, Boss boss, Texture2D blokTexture, StartScreen startScreen, FirstLevel firstLevel, FinalLevel finalLevel, Goal goal, GameOver gameOver)
        {
            this.player = player;
            this.enemy = enemy;
            this.boss = boss;
            this.blokTexture = blokTexture;
            this.startScreen = startScreen;
            this.firstLevel = firstLevel;
            this.finalLevel = finalLevel;
            this.goal = goal;
            this.gameOver = gameOver;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
  
            if (currentState == Gamestates.Start)
                startScreen.Draw(spriteBatch);

            if (currentState == Gamestates.FirstLevel)
            {
                firstLevel.Draw(spriteBatch);
                player.Draw(spriteBatch);
                obstakel = new Rectangle(400, 400, 30, 30);

                spriteBatch.Draw(blokTexture, new Rectangle(400, 400, 30, 30), Color.Black);
            }

            if (currentState == Gamestates.FinalLevel)
            {
                finalLevel.Draw(spriteBatch);
                player.Draw(spriteBatch);
                spriteBatch.Draw(blokTexture, new Rectangle(400, 400, 30, 30), Color.Black);
            }

            if (currentState == Gamestates.Goal)
            {
                goal.Draw(spriteBatch);
                player.Draw(spriteBatch);
                spriteBatch.Draw(blokTexture, new Rectangle(400, 400, 30, 30), Color.Black);
            }

            if (currentState == Gamestates.GameOver)
            {
                gameOver.Draw(spriteBatch);
                player.Draw(spriteBatch);
                spriteBatch.Draw(blokTexture, new Rectangle(400, 400, 30, 30), Color.Black);
            }
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            startScreen.Update(gameTime);
            firstLevel.Update(gameTime);

            if (player.HitBox.Intersects(obstakel))
                player.IsHit = true;
            

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start || currentState == Gamestates.GameOver)
                currentState = Gamestates.FirstLevel;
            //if (true)
            //    currentState = Gamestates.FinalLevel;
            //if (boss.IsDead == true && currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.Goal;
            if (player.IsDead == true && currentState == Gamestates.FirstLevel || currentState == Gamestates.FinalLevel)
                currentState = Gamestates.GameOver;
        }
    }
}
