﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            :base(game, location, 6)
        { }

        public override void Move(Random random)
        {
            // Re-think if it is better to stay put if no hit points
            if (HitPoints > 0)
            {
                if (random.Next(0, 100) < 50) base.location = base.Move((Direction)random.Next(1, 4), game.Boundaries);
                else base.location = base.Move(base.FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                
                // Check if player is near in order to attack
                if (NearPlayer()) game.HitPlayer(2, random);
            }
            
            
        }
    }
}
