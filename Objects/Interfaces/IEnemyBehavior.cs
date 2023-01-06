using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Objects.Interfaces
{
    internal interface IEnemyBehavior
    {
        public int limit1 { get; set; }
        public int limit2 { get; set; }
        public Vector2 Position { get; protected set; }
        public bool Flip { get; protected set; }
        public void Move();
    }
}
