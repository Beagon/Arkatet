using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project_Dustcrazy
{
    public class Move60PercentUp : IBall
    {
        private Ball Ball;

        public Move60PercentUp(Ball b)
        {
            this.Ball = b;
        }
        public void Update(GameTime gt)
        {
            if (Ball.Side == false)
            {
                Ball.bY = Ball.bYGet.Y - 1;
            }
            else
            {
                Ball.bY = Ball.bYGet.Y + 1;
            }
        }
    }


}
