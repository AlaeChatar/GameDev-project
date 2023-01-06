using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameDev_project.Gamescreens.ScreenManager;

namespace GameDev_project.Objects.Interfaces
{
    internal interface IHealth
    {
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsHit { get; set; }
        public float Invulnerability { get; set; }

        void ShowHealth(SpriteBatch spriteBatch, Texture2D texture, Vector2 position);
        
    }
}
