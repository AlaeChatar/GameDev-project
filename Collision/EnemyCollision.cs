using GameDev_project.Characters;
using GameDev_project.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_project.Collision
{
    internal class EnemyCollision
    {
        public void TouchEnemy(Hero hero, List<Enemy> enemies, GameTime gameTime)
        {
            foreach (Walker enemy in enemies.OfType<Walker>())
            {
                enemy.Update(gameTime);
                if (hero.HitBox.Intersects(enemy.HitBox))
                    hero.IsHit = true;
            }

            foreach (Jumper enemy in enemies.OfType<Jumper>())
            {
                enemy.Update(gameTime);
                if (hero.HitBox.Intersects(enemy.HitBox))
                    hero.IsHit = true;
            }
        }
    }
}
