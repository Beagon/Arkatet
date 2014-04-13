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
    public class PaddleUp : IPaddle
    {
        private Paddle paddle;

        public PaddleUp(Paddle p)
        {
            this.paddle = p;
        }

        public void Update(GameTime gt)
        {
            if (paddle.PaddleRect.Y >= 0)
            {
                this.paddle.PaddleRectY = paddle.PaddleRect.Y - 5;
            }
        }

    }
}
