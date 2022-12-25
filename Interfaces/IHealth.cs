using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Interfaces
{
    internal interface IHealth
    {
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }

        void TakeDamage(GameTime ganeTime);
        void Respawn();
    }
}
