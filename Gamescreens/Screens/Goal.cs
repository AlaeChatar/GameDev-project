using GameDev_project.Animations;
using GameDev_project.Gamescreens.Interfaces;
using GameDev_project.Objects.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Gamescreens.Screens
{
    internal class Goal : Screen, IDisplay
    {
        Animation animation;
        Level level1, level2;

        public Goal(Texture2D texture, SpriteFont font, Level level1, Level level2)
        {
            this.texture = texture;
            this.font = font;
            this.level1 = level1;
            this.level2 = level2;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 1);
        }

        public void PrintScreen(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(60, 0, 800, 400), animation.CurrentFrame.SourceRectangle, Color.White);
            if(level1.CounterEggs + level2.CounterEggs < 1)
                spriteBatch.DrawString(font, "You survived! But ignored my golden eggs...", new Vector2(960 / 2 - font.MeasureString("You survived! But ignored my golden eggs...").Length() / 2, 400), Color.White);
            else if (level1.CounterEggs + level2.CounterEggs <= 3)
                spriteBatch.DrawString(font, $"Not bad, you collected {level1.CounterEggs + level2.CounterEggs} out of 8 eggs", new Vector2(960 / 2 - font.MeasureString($"Not bad, you collected {level1.CounterEggs + level2.CounterEggs} out of 8 eggs").Length() / 2, 400), Color.White);
            else if (level1.CounterEggs + level2.CounterEggs <= 7)
                spriteBatch.DrawString(font, "Good job, you almost got all the eggs", new Vector2(960 / 2 - font.MeasureString("Good job, you almost got all the eggs").Length() / 2, 400), Color.White);
            else if (level1.CounterEggs + level2.CounterEggs == 8)
                spriteBatch.DrawString(font, "WOW! You collected all the eggs!", new Vector2(960 / 2 - font.MeasureString("WOW! You collected all the eggs!").Length() / 2, 400), Color.White);
        }

        public void RefreshScreen(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
