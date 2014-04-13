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
    public class Ball
    {
        public bool Side;

        private ContentManager _content;
        private Texture2D ballText;
        private Rectangle ballRect;
        private IBall state;
        private Paddle Paddle;
        private KeyboardState kState;
        private int XSpeed;
        private int Direction;
        public bool GameStarted;
        public Ball(ContentManager content, Paddle p)
        {
        ballText = content.Load<Texture2D>(@"images/Game/Ball");
        ballRect = new Rectangle(720, 150, 15, 15);
         _content = content;
         Paddle = p;
         this.state = new BallStart(this, this.Paddle);
         XSpeed = 0;
         Direction = 1;
        }

        public int bY
        {
            set
            {
                ballRect.Y = value;
            }
        }

        public int direction
        {
            set
            {
                Direction = value;
            }
        }

        public int directionGet
        {
            get
            {
              return Direction;
            }
        }

        public int bX
        {
            set
            {
                ballRect.X = value;
            }
        }

        public Rectangle bYGet
        {
            get
            {
                return ballRect;
            }
        }

        public void Update(GameTime gt, Tetris tetris)
        {
           kState = Keyboard.GetState();
           if (Direction == 1)
           {
               ballRect.X = ballRect.X - XSpeed;
           }else{
               ballRect.X = ballRect.X + XSpeed;
           }
           if (kState.IsKeyDown(Keys.Space) && !GameStarted && tetris.TetDone)
           {
               XSpeed = 10;
               GameStarted = true;
               this.state = new Move0PercentUp(this);
           }
           if (GameStarted == true)
           {
               if (ballRect.Y <= 0)
               {
                   Side = true;
               }
               else if (ballRect.Y >= 630)
               {
                   Side = false;
               }
               if (ballRect.X + ballRect.Width >= Paddle.PaddleRect.X && ballRect.Y + ballRect.Height >= Paddle.PaddleRect.Y && ballRect.Y + ballRect.Height <= Paddle.PaddleRect.Y + Paddle.PaddleRect.Height)
               {
                    if (ballRect.Y <= Paddle.PaddleRect.Y + 10)
                    {
                        Side = false;
                        this.state = new Move10PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 20)
                    {
                        Side = false;
                        this.state = new Move20PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 30)
                    {
                        Side = false;
                        this.state = new Move30PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 40)
                    {
                        Side = false;
                        this.state = new Move40PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 50)
                    {
                        Side = false;
                        this.state = new Move50PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Center.Y)
                    {
                        this.state = new Move0PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 70)
                    {
                        Side = true;
                        this.state = new Move60PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 80)
                    {
                        Side = true;
                        this.state = new Move70PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 90)
                    {
                        Side = true;
                        this.state = new Move80PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 100)
                    {
                        Side = true;
                        this.state = new Move90PercentUp(this);
                    }
                    else if (ballRect.Y <= Paddle.PaddleRect.Y + 110 && ballRect.Y >= Paddle.PaddleRect.Y + 100)
                    {
                        Side = true;
                        this.state = new Move100PercentUp(this);
                    }
                    //this.state = new Move0PercentUp(this);                       

                   Direction = 1;
               }

                  // Direction = 1;
               if (ballRect.X <= 0)
               {
                   Direction = 0;
               }

               if (ballRect.X > 1280)
               {
                   //ballRect = new Rectangle(720, 150, 15, 15);
                   tetris.ArkScore = tetris.ArkScore - 500;
                   GameStarted = false;
                   this.state = new BallStart(this, this.Paddle);
                   XSpeed = 0;
                   Direction = 1;
               }
           }

           this.state.Update(gt);
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(ballText, ballRect, Color.White);
        }
    }
}
