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
    public class Paddle
    {
        //Properties
        ContentManager _content;
        Texture2D paddletext;
        Rectangle paddleRect;
        KeyboardState kState;
        private IPaddle state;

        public Paddle(ContentManager content)
        {
         paddletext = content.Load<Texture2D>(@"images/Game/padle");
         paddleRect = new Rectangle(1250, 318, 18, 90);
         _content = content;
         this.state = new PaddleNoMovement(this);
         
        }

        public Rectangle PaddleRect
        {
            get { return this.paddleRect; }
            
        }
        
        public int PaddleRectY
        {
            set { this.paddleRect.Y = value; }
        }

        public void Update(GameTime gt)
        {
            kState = Keyboard.GetState();
            this.state.Update(gt);
           
                if (kState.IsKeyDown(Keys.Up))
                {
                    this.state = new PaddleUp(this);
                }
                else if (!kState.IsKeyDown(Keys.Down))
                {
                    this.state = new PaddleNoMovement(this);
                }

                if (kState.IsKeyDown(Keys.Down))
                {
                    this.state = new PaddleDown(this);
                }
                else if (!kState.IsKeyDown(Keys.Up))
                {
                    this.state = new PaddleNoMovement(this);
                }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(paddletext, paddleRect, Color.White);
        }

    }
}
