using GameDev_project.Gamescreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Sound
{
    static class Soundtrack
    {
        private static SoundEffect soundtrack;
        private static SoundEffectInstance soundtrackInstance;
        private static SoundEffect intro;
        private static SoundEffectInstance introInstance;
        private static SoundEffect fail;
        private static SoundEffectInstance failInstance;
        private static SoundEffect clear;
        private static SoundEffectInstance clearInstance;

        public static void Initialize(ContentManager content)
        {
            intro = content.Load<SoundEffect>("Soundtrack/Glavenus_Theme");
            introInstance = intro.CreateInstance();
            introInstance.Volume = 0.3f;
            soundtrack = content.Load<SoundEffect>("Soundtrack/Valstrax_Theme");
            soundtrackInstance = soundtrack.CreateInstance();
            soundtrackInstance.Volume = 0.1f;
            clear = content.Load<SoundEffect>("Soundtrack/Proof_of_a_Hero");
            clearInstance = clear.CreateInstance();
            clearInstance.Volume = 0.3f;
            fail = content.Load<SoundEffect>("Soundtrack/Game_Over");
            failInstance = fail.CreateInstance();
            failInstance.Volume = 0.3f;
        }

        public static void Play()
        {
            switch (currentState)
            {
                case GameStates.Start:
                    introInstance.Play();
                    introInstance.IsLooped = true;
                    soundtrackInstance.Stop();
                    clearInstance.Stop();
                    failInstance.Stop();
                    break;
                case GameStates.Level1:
                case GameStates.Level2:
                    introInstance.Stop();
                    soundtrackInstance.Play();
                    soundtrackInstance.IsLooped = true;
                    clearInstance.Stop();
                    failInstance.Stop();
                    break;
                case GameStates.GameOver:
                    introInstance.Stop();
                    soundtrackInstance.Stop();
                    clearInstance.Stop();
                    failInstance.Play();
                    failInstance.IsLooped = true;
                    break;
                case GameStates.Goal:
                    introInstance.Stop();
                    soundtrackInstance.Stop();
                    clearInstance.Play();
                    clearInstance.IsLooped = true;
                    failInstance.Stop();
                    break;
            }
        }
    }
}
