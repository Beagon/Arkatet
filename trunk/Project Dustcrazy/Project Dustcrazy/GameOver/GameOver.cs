using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GameOver
    {
        private ContentManager Content;
        private SpriteFont Arial;
        private int ScorePlayer1;
        private int ScorePlayer2;
        private Texture2D titlebg, TetWon, ArkWon, BackButton;
        private Rectangle BackButtonRect;
        private MouseState mState, OldmState;
        public GameOver(ContentManager c)
        {
            Content = c;
            TetWon = Content.Load<Texture2D>(@"images/TetrisWon");
            ArkWon = Content.Load<Texture2D>(@"images/ArkanoidWon");
            titlebg = Content.Load<Texture2D>(@"images/Backgrounds/titlescreen");
            BackButton = Content.Load<Texture2D>(@"images/Buttons/Exit");
            BackButtonRect = new Rectangle(500, 600, 300, 100);
            Arial = Content.Load<SpriteFont>(@"arial");
        }
        
        public void Update(GameTime gt, int Score1, int Score2, Arktet arktet)
        {
            ScorePlayer1 = Score2;
            ScorePlayer2 = Score1;
            mState = Mouse.GetState();
            if (mState.X > BackButtonRect.Left && mState.X < BackButtonRect.Right &&
                       mState.Y > BackButtonRect.Top && mState.Y < BackButtonRect.Bottom)
            {
                BackButton = Content.Load<Texture2D>(@"images/Buttons/ExitHover");
                if (mState.LeftButton == ButtonState.Pressed && OldmState.LeftButton == ButtonState.Released)
                {
                    arktet.Exit();
                }
            }
            else
            {
                BackButton = Content.Load<Texture2D>(@"images/Buttons/Exit");
            }
            OldmState = mState;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(titlebg, new Vector2(0, 0), Color.White);
            if (ScorePlayer1 > ScorePlayer2)
            {
                sb.Draw(TetWon, new Vector2(240, 170), Color.White);
            }
            else if (ScorePlayer2 > ScorePlayer1)
            {
                sb.Draw(ArkWon, new Vector2(240, 170), Color.White);
            }
            else if (ScorePlayer1 == ScorePlayer2)
            {
                sb.DrawString(Arial, "It's a tie!", new Vector2(240, 200), Color.White);
            }
            sb.Draw(BackButton, BackButtonRect, Color.White);
            //sb.DrawString(Arial, ScorePlayer1.ToString(), new Vector2(200, 200), Color.Black);
            //sb.DrawString(Arial, ScorePlayer2.ToString(), new Vector2(400, 200), Color.Black);
        }
    }
}
