using GameDev_project.Map;
using GameDev_project.Objects.Characters;
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
    public enum Gamestates { Start, Level1, Level2, GameOver, Goal }
    internal class ScreenManager
    {
        public static Gamestates currentState = Gamestates.Start;

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
            Music.ChangeTrack(currentState);
            Music.Play();
        }

        public void Update(GameTime gameTime)
        {
            if (currentState == Gamestates.Level1)
                level1.Update(gameTime);
            if (currentState == Gamestates.Level2)
                level2.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentState == Gamestates.Start)
                currentState = Gamestates.Level1;
            if (hero1.health.IsDead == true || hero2.health.IsDead == true)
                currentState = Gamestates.GameOver;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == Gamestates.GameOver && hero1.health.IsDead == true)
                currentState = Gamestates.Level1;
            if (Keyboard.GetState().IsKeyDown(Keys.R) && currentState == Gamestates.GameOver && hero2.health.IsDead == true)
                currentState = Gamestates.Level2;            
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
