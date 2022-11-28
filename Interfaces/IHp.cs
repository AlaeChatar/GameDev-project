using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Interfaces
{
    internal interface IHp
    {
        public int HP { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }

        public int HealthBar()
        {
            if (IsHit == true)
                HP--;
            if (HP == 0)
                IsDead = true;
            
            return HP;
        }
    }
}
