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
        Texture2D blokTexture;
        Enemy enemy;
        Boss boss;


        public ScreenManager(Player player, Texture2D blokTexture, StartScreen startScreen, FirstLevel firstLevel)
        {
            this.player = player;
            this.blokTexture = blokTexture;
            this.startScreen = startScreen;
            this.firstLevel = firstLevel;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
  
            if (currentState == Gamestates.Start)
                startScreen.Draw(spriteBatch);

            if (currentState == Gamestates.FirstLevel)
            {
                firstLevel.Draw(spriteBatch);
                player.Draw(spriteBatch);
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

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                currentState = Gamestates.FirstLevel;
        }
    }
}
