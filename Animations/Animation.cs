using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<List<AnimationFrame>> animations;
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;


        public Animation()
        {
            animations = new List<List<AnimationFrame>>();
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 16;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;

            for (int x = 0; x <= numberOfWidthSprites; x++)
            {
                frames.Add(new AnimationFrame(new Rectangle(x * 640, height, widthOfFrame, 640)));
            }

            animations.Add(frames);
        }
    }
}
