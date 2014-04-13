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
    public class BallStart : IBall
    {
        private Ball Ball;
        private Paddle Paddle;

        public BallStart(Ball b, Paddle p)
        {
            this.Ball = b;
            this.Paddle = p;
        }
        public void Update(GameTime gt)
        {
            Ball.bY = Paddle.PaddleRect.Center.Y - 5;
            Ball.bX = Paddle.PaddleRect.X - 15;
        }
    }
}
