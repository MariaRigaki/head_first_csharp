using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    abstract class Weapon : Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
            : base(game, location) 
        {
            PickedUp = false;
        }

        public void PickUpWeapon() { PickedUp = true; }

        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius,
        int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                //target = Move(direction, target, game.Boundaries);
            }
            
            return false;
        }

        private Point Move(Direction direction, Point target, Rectangle rectangle)
        {
            location = target;
            return base.Move(direction, rectangle);
        }

        private bool Nearby(Point point, Point target, int distance)
        {
            //location = target;
            //return base.Nearby(point, distance);

            if (Math.Abs(point.X - target.X) <= distance &&
           (Math.Abs(point.Y - target.Y) <= distance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
