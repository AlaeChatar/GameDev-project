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
    public static class Music
    {
        static Song soundtrack;
        static Song intro;
        static Song clear;
        static Song fail;
        static Song song;

        public static void Initialize(ContentManager content)
        {
            soundtrack = content.Load<Song>("Soundtrack/A_Hero_Return");
            intro = content.Load<Song>("Soundtrack/Proof_of_a_Hero");
            clear = content.Load<Song>("Soundtrack/Quest_Clear");
            fail = content.Load<Song>("Soundtrack/Quest_Failed");
        }

        public static void ChangeTrack()
        {
            if (currentState == Gamestates.Start)
                song = intro;
            if (currentState == Gamestates.Level1 || currentState == Gamestates.Level2)
                song = soundtrack;
            if (currentState == Gamestates.Goal)
                song = clear;
            if (currentState == Gamestates.GameOver)
                song = fail;
        }

        public static void Play()
        {
            MediaPlayer.Play(song);
        }
    }
}
