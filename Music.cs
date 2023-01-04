using GameDev_project.Gamescreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project
{
    internal class Music
    {
        Song soundtrack;
        Song intro;
        Song clear;
        Song fail;

        private static bool isPlaying = false;

        public Music(Song intro, Song background, Song clear, Song fail)
        {
            this.intro = intro;
            soundtrack = background;
            this.clear = clear;
            this.fail = fail;
        }

        public void Play()
        {
            MediaPlayer.IsRepeating = true;

            if ((currentState == GameStates.Level1 || currentState == GameStates.Level2))
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(soundtrack);
                isPlaying = true;
            }
            if (currentState == GameStates.Start && isPlaying == false)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(intro);
                isPlaying = true;
            }
            if (currentState == GameStates.Goal && isPlaying == false)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(clear);
                isPlaying = true;
            }
            if (currentState == GameStates.GameOver && isPlaying == false)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(fail);
                isPlaying = true;
            }
        }
    }
}
