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
    class Settings
    {
        //properties
        Texture2D BackButton, titlebg, PlusButton, MinButton;
        Rectangle BackButtonRect, PlusButtonRect, MinButtonRect;
        SpriteFont arialbigblue;
        Arktet ark;
        //Settings
        MouseState mState, OldmState;
        ContentManager _content;

        //Constructor
        public Settings(ContentManager content, Arktet ArkTet)
        {
            ark = ArkTet;
            PlusButton = content.Load<Texture2D>(@"images/Buttons/+Button");
            MinButton = content.Load<Texture2D>(@"images/Buttons/-Button");
            titlebg = content.Load<Texture2D>(@"images/Backgrounds/titlescreen");
            arialbigblue = content.Load<SpriteFont>(@"arialbluebig");
            BackButton = content.Load<Texture2D>(@"images/Buttons/Back");
            BackButtonRect = new Rectangle(500, 600, 300, 100);
            PlusButtonRect = new Rectangle(550, 192, PlusButton.Width, PlusButton.Height);
            MinButtonRect = new Rectangle(750, 192, MinButton.Width, MinButton.Height);

         _content = content;
        }

        public void Update()
        {
            mState = Mouse.GetState();
            if (mState.X > BackButtonRect.Left && mState.X < BackButtonRect.Right &&
                       mState.Y > BackButtonRect.Top && mState.Y < BackButtonRect.Bottom)
            {
                BackButton = _content.Load<Texture2D>(@"images/Buttons/BackHover");
                if (mState.LeftButton == ButtonState.Pressed && OldmState.LeftButton == ButtonState.Released)
                {
                    Arktet.gameState = Arktet.GameState.title;
                }
            }
            else
            {
                BackButton = _content.Load<Texture2D>(@"images/Buttons/Back");
            }


            //PlusButton
            if (mState.X > PlusButtonRect.Left && mState.X < PlusButtonRect.Right &&
           mState.Y > PlusButtonRect.Top && mState.Y < PlusButtonRect.Bottom)
            {
                PlusButton = _content.Load<Texture2D>(@"images/Buttons/+ButtonHover");
                if (mState.LeftButton == ButtonState.Pressed && OldmState.LeftButton == ButtonState.Released)
                {
                    if((ark.volume + 0.05) <= 1.05f){
                    ark.volume = ark.volume + 0.05f;
                    }
                }
            }
            else
            {
                PlusButton = _content.Load<Texture2D>(@"images/Buttons/+Button");
            }



            //MinButton
            if (mState.X > MinButtonRect.Left && mState.X < MinButtonRect.Right &&
           mState.Y > MinButtonRect.Top && mState.Y < MinButtonRect.Bottom)
            {
                MinButton = _content.Load<Texture2D>(@"images/Buttons/-ButtonHover");
                if (mState.LeftButton == ButtonState.Pressed && OldmState.LeftButton == ButtonState.Released)
                {
                    if ((ark.volume - 0.05) >= 0.0f)
                    {
                        ark.volume = ark.volume - 0.05f;
                    }
                    else
                    {
                        ark.volume = 0.0f;
                    }
                }
            }
            else
            {
                MinButton = _content.Load<Texture2D>(@"images/Buttons/-Button");
            }
            OldmState = mState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titlebg, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(BackButton, BackButtonRect, Color.White);
            spriteBatch.Draw(PlusButton, PlusButtonRect, Color.White);
            spriteBatch.Draw(MinButton, MinButtonRect, Color.White);
            spriteBatch.DrawString(arialbigblue, "Volume: " + Math.Round((ark.volume*100)).ToString(), new Vector2(300, 200), Color.White);
        }
    }
}
