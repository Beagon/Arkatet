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
    public class PaddleDown : IPaddle
    {
        private Paddle paddle;

        public PaddleDown(Paddle p)
        {
            this.paddle = p;
        }

        public void Update(GameTime gt)
        {
            if (paddle.PaddleRect.Y <= 720 - paddle.PaddleRect.Height - 85)
            {
                this.paddle.PaddleRectY = this.paddle.PaddleRect.Y + 5;
            }
        }
    }
}
