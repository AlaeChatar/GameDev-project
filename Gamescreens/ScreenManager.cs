using GameDev_project.Map;
using GameDev_project.Objects.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    public enum GameStates { Start, Level1, Level2, GameOver, Goal }
    internal class ScreenManager
    {
        public static GameStates currentState;

        //Screens
        Start startScreen;
        Level level1;
        Level level2;
        GameOver gameOver;
        Goal goal;

        // Player
        Hero hero1;
        Hero hero2;

        public ScreenManager(Start startScreen, Level level1, Level level2, Goal goal, GameOver gameOver, Hero hero1, Hero hero2)
        {
            this.startScreen = startScreen;
            this.level1 = level1;
            this.level2 = level2;
            this.goal = goal;
            this.gameOver = gameOver;

            this.hero1 = hero1;
            this.hero2 = hero2;

            currentState = GameStates.Start;
        }

        public void Update(GameTime gameTime)
        {
            if (currentState == GameStates.Level1)
                level1.Update(gameTime);
            if (currentState == GameStates.Level2)
                level2.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == GameStates.Start)
                currentState = GameStates.Level1;
            if (hero1.health.IsDead == true || hero2.health.IsDead == true)
                currentState = GameStates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == GameStates.GameOver && hero1.health.IsDead == true)
                currentState = GameStates.Level1;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == GameStates.GameOver && hero2.health.IsDead == true)
                currentState = GameStates.Level2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentState)
            {   
                case GameStates.Start:
                    startScreen.Draw(spriteBatch);
                    break;
                case GameStates.Level1:
                    level1.Draw(spriteBatch);
                    break;
                case GameStates.Level2:
                    level2.Draw(spriteBatch);
                    break;
                case GameStates.GameOver:
                    gameOver.Draw(spriteBatch);
                    break;
                case GameStates.Goal:
                    goal.Draw(spriteBatch);
                    break;
            }
        }

    }
}
