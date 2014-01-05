using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location) { }
        public override string Name { get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 15, 3, random);
            int dir = (int)direction + 2;
            DamageEnemy((Direction)(dir % 4), 15, 3, random);
            dir++;
            DamageEnemy((Direction)(dir % 4), 15, 3, random);

        }


        
        
    }
}
