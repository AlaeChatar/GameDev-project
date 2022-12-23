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
        public enum Gamestates { Start, Level1, Level2, GameOver, Goal }
        public static Gamestates currentState = Gamestates.Start;

        SpriteFont font;

        //Screens
        Start startScreen;
        Level level1;
        Level level2;
        GameOver gameOver;
        Goal goal;

        public ScreenManager(Start startScreen, Level level1, Level level2, Goal goal, GameOver gameOver, SpriteFont font)
        {
            this.startScreen = startScreen;
            this.level1 = level1;
            this.level2 = level2;
            this.goal = goal;
            this.gameOver = gameOver;

            this.font = font;
        }

        public void Update(GameTime gameTime)
        {
            if (currentState == Gamestates.Level1)
                level1.Update(gameTime);
            if (currentState == Gamestates.Level2)
                level2.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start)
                currentState = Gamestates.Level1;
            //if (boss.IsDead == true && currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.Goal;
            //if (player.IsDead == true && currentState == Gamestates.FirstLevel || currentState == Gamestates.FinalLevel)
            //    currentState = Gamestates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == Gamestates.GameOver)
                currentState = Gamestates.Level1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentState)
            {   
                case Gamestates.Start:
                    startScreen.Draw(spriteBatch);
                    break;
                case Gamestates.Level1:
                    level1.Draw(spriteBatch);
                    break;
                case Gamestates.Level2:
                    level2.Draw(spriteBatch);
                    break;
                case Gamestates.GameOver:
                    gameOver.Draw(spriteBatch);
                    break;
                case Gamestates.Goal:
                    goal.Draw(spriteBatch);
                    break;
            }
        }

    }
}
