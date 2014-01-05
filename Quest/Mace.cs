using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location) { }
        public override string Name { get { return "Mace"; } }

        public override void Attack(Direction direction, Random random)
        {
            int dir = (int) direction;

            for (int i = 0; i < 4; i++)
            {
                dir += i;
                DamageEnemy((Direction) (dir % 4), 20, 6, random);
            }
                
        }
    }
}
