using GameDev_project.Objects.Characters;
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
                hero.HitBox = new Rectangle(hero.HitBox.X, newRect.Y - hero.HitBox.Height, 30, 30);
                hero.Velocity = new Vector2(hero.Velocity.X, 0f);
                hero.HasJumped = false;
            }
            if (hero.HitBox.TouchLeftOf(newRect))
                hero.Position = new Vector2(newRect.X - hero.HitBox.Width - 2, hero.Position.Y);
            if (hero.HitBox.TouchRightOf(newRect))
                hero.Position = new Vector2(newRect.X + newRect.Width + 2, hero.Position.Y);
            if (hero.HitBox.TouchBottomOf(newRect))
                hero.Velocity = new Vector2(hero.Velocity.X, 1f);

            if (hero.Position.X < 0) hero.Position = new Vector2(0, hero.Position.Y);
            if (hero.Position.X > xOffset - hero.HitBox.Width) hero.Position = new Vector2(xOffset - hero.HitBox.Width, hero.Position.Y);
            if (hero.Position.Y < 0) hero.Velocity = new Vector2(hero.Velocity.X, 1f);
            if (hero.Position.Y > xOffset - hero.HitBox.Height) hero.Position = new Vector2(hero.Position.X, yOffset - hero.HitBox.Height);
        }
    }
}
