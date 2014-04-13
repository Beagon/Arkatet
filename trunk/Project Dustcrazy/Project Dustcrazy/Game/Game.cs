using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project_Dustcrazy
{
    class Game
    {
         //properties
        ContentManager _content;
        Texture2D gamebg, StopGame;
        Rectangle StopGameRect;
        MouseState mState, OldmState;
        KeyboardState kState;
        Paddle paddle;
        Ball ball;
        Tetris Tet;
        public int Score1, Score2;
        private SpriteFont arial;
        //Settings


        //ConstructorMovables
        public Game(ContentManager content)
        {
            arial = content.Load<SpriteFont>(@"arial");
           gamebg = content.Load<Texture2D>(@"images/Backgrounds/GameBG");
         StopGame = content.Load<Texture2D>(@"images/Buttons/StopGame");
         paddle = new Paddle(content);
         ball = new Ball(content, paddle);
         Tet = new Tetris(content, paddle, ball);
         StopGameRect = new Rectangle(1100, 650, StopGame.Width, StopGame.Height);
         _content = content;
        }

        public void Update(GameTime gt)
        {
            Score1 = Tet.ArkScore;
            Score2 = Tet.TetScore;
            mState = Mouse.GetState();
            kState = Keyboard.GetState();
            paddle.Update(gt);
            Tet.Update(gt);
            ball.Update(gt, Tet);
            OldmState = mState;
            if (mState.X > StopGameRect.Left && mState.X < StopGameRect.Right &&
               mState.Y > StopGameRect.Top && mState.Y < StopGameRect.Bottom)
            {
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Arktet.gameState = Arktet.GameState.title;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(gamebg, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(StopGame, StopGameRect, Color.White);
            paddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            Tet.Draw(spriteBatch);
            if (Tet.TetDone && !ball.GameStarted)
            {
                spriteBatch.DrawString(arial, "Press Space too start!", new Vector2(650, 360), Color.White);
            }
            else if(!ball.GameStarted)
            {
                spriteBatch.DrawString(arial, "Please wait till the other player has placed his blocks.", new Vector2(650, 360), Color.White);
            }
        }
    }
}
