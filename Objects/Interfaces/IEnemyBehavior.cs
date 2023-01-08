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
        public Vector2 Position { get; set; }
        public bool Turn { get; set; }
        public int Limit1 { get; set; }
        public int Limit2 { get; set; }
        public void Movement();
    }
}
