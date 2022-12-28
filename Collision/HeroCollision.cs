using GameDev_project.Characters;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDev_project.Collision
{
    internal class HeroCollision
    {
        public void Collide(Hero hero, Rectangle newRect, int xOffset, int yOffset)
        {
            if (hero.HitBox.TouchTopOf(newRect))
            {
                hero.hitBox.Y = newRect.Y - hero.hitBox.Height;
                hero.velocity.Y = 0f;
                hero.hasJumped = false;
            }
            if (hero.hitBox.TouchLeftOf(newRect))
                hero.position.X = newRect.X - hero.hitBox.Width - 2;
            if (hero.hitBox.TouchRightOf(newRect))
                hero.position.X = newRect.X + newRect.Width + 2;
            if (hero.hitBox.TouchBottomOf(newRect))
                hero.velocity.Y = 1f;

            if (hero.position.X < 0) hero.position.X = 0;
            if (hero.position.X > xOffset - hero.hitBox.Width) hero.position.X = xOffset - hero.hitBox.Width;
            if (hero.position.Y < 0) hero.velocity.Y = 1f;
            if (hero.position.Y > xOffset - hero.hitBox.Height) hero.position.Y = yOffset - hero.hitBox.Height;
        }
    }
}
