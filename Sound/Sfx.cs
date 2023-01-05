using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Sound
{
    static class Sfx
    {
        private static SoundEffect hurt;
        private static SoundEffectInstance hurtInstance;
        private static SoundEffect collect;
        private static SoundEffectInstance collectInstance;

        public static void Initialize(ContentManager content)
        {
            collect = content.Load<SoundEffect>("Soundtrack/pickup");
            collectInstance = collect.CreateInstance();
            collectInstance.Volume = 0.3f;
            hurt = content.Load<SoundEffect>("Soundtrack/hurt");
            hurtInstance = hurt.CreateInstance();
            hurtInstance.Volume = 0.2f;
        }

        public static void Hurt()
        {
            hurtInstance.Play();
        }

        public static void Collect()
        {
            collectInstance.Play();
        }
    }
}
