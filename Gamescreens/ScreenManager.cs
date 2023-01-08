using GameDev_project.Gamescreens.Screens;
using GameDev_project.Map;
using GameDev_project.Objects.Characters;
using GameDev_project.Objects.Characters.LifeSpan;
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
    internal class ScreenManager
    {
        public enum GameStates 
        { 
            Start, 
            Level1, 
            Level2, 
            GameOver, 
            Goal 
        }

        private static GameStates currentState = GameStates.Start;
        public static GameStates CurrentState 
        { 
            get { return currentState; } 
            set { currentState = value; }
        }

        SpriteFont font;

        //Screens
        Start startScreen;
        Level level1;
        Level level2;
        GameOver gameOver;
        Goal goal;

        // Player
        Hero hero1;
        Hero hero2;
        Life life;

        public ScreenManager(SpriteFont font, Start startScreen, Level level1, Level level2, Goal goal, GameOver gameOver, Hero hero1, Hero hero2, Life life)
        {
            this.font = font;
            this.startScreen = startScreen;
            this.level1 = level1;
            this.level2 = level2;
            this.goal = goal;
            this.gameOver = gameOver;

            this.hero1 = hero1;
            this.hero2 = hero2;
            this.life = life;
        }

        public void ChangeState()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == GameStates.Start)
                currentState = GameStates.Level1;
            if (hero1.Health.IsDead == true || hero2.Health.IsDead == true)
                currentState = GameStates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == GameStates.GameOver && life.IsDead == true)
            {
                currentState = GameStates.Level1;
                hero1.Position = hero1.Spawn;
                hero2.Position = hero2.Spawn;
            }
        }

        public void Update(GameTime gameTime)
        {
            ChangeState();

            switch (currentState)
            {
                case GameStates.Start:
                    startScreen.RefreshScreen(gameTime);
                    break;
                case GameStates.Level1:
                    level1.RefreshScreen(gameTime);
                    break;
                case GameStates.Level2:
                    level2.RefreshScreen(gameTime);
                    break;
                case GameStates.GameOver:
                    gameOver.RefreshScreen(gameTime);
                    break;
                case GameStates.Goal:
                    goal.RefreshScreen(gameTime);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentState)
            {   
                case GameStates.Start:
                    startScreen.PrintScreen(spriteBatch);
                    break;
                case GameStates.Level1:
                    level1.PrintScreen(spriteBatch);
                    spriteBatch.DrawString(font, $"Eggs: {level1.CounterEggs + level2.CounterEggs}/8", new Vector2(hero1.Position.X - 25, hero1.Position.Y - 60), Color.White);
                    break;
                case GameStates.Level2:
                    level2.PrintScreen(spriteBatch);
                    spriteBatch.DrawString(font, $"Eggs: {level1.CounterEggs + level2.CounterEggs}/8", new Vector2(hero2.Position.X - 25, hero2.Position.Y - 60), Color.White);
                    break;
                case GameStates.GameOver:
                    gameOver.PrintScreen(spriteBatch);
                    break;
                case GameStates.Goal:
                    goal.PrintScreen(spriteBatch);
                    break;
            }
        }

    }
}
