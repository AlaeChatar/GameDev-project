using GameDev_project.Objects.Characters;
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
                if (hero.hitBox.Intersects(enemy.hitBox))
                    hero.health.IsHit = true;
            }

            foreach (Jumper enemy in enemies.OfType<Jumper>())
            {
                enemy.Update(gameTime);
                if (hero.hitBox.Intersects(enemy.hitBox))
                    hero.health.IsHit = true;
            }
        }
    }
}
