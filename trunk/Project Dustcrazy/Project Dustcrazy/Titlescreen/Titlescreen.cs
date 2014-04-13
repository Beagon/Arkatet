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
    class Titlescreen
    {
        //properties

        //titlescreen
        Texture2D titlebg, PlayButton, SettingsButton, ExitButton;
        Rectangle PlayButtonRect, SettingsButtonRect, ExitButtonRect;
        //Settings
        MouseState mState, OldmState;
        ContentManager contents;

        //Constructor
        public Titlescreen(ContentManager content)
        {
            //Titlescreen
            contents = content;
            titlebg = content.Load<Texture2D>(@"images/Backgrounds/titlescreen");
            PlayButton = content.Load<Texture2D>(@"images/Buttons/Play");
            SettingsButton = content.Load<Texture2D>(@"images/Buttons/Settings");
            ExitButton = content.Load<Texture2D>(@"images/Buttons/Exit");
            PlayButtonRect = new Rectangle(500, 200, 300, 100);
            SettingsButtonRect = new Rectangle(500, 325, 300, 100);
            ExitButtonRect = new Rectangle(500, 450, 300, 100);


        }

        public void Update()
        {
            mState = Mouse.GetState();
            //Play Button
            if (mState.X > PlayButtonRect.Left && mState.X < PlayButtonRect.Right &&
              mState.Y > PlayButtonRect.Top && mState.Y < PlayButtonRect.Bottom)
            {
                PlayButton = contents.Load<Texture2D>(@"images/Buttons/PlayHover");
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Arktet.gameState = Arktet.GameState.game;
                }
            }
            else
            {
                PlayButton = contents.Load<Texture2D>(@"images/Buttons/Play");
            }

            //Settings Button
            if (mState.X > SettingsButtonRect.Left && mState.X < SettingsButtonRect.Right &&
                mState.Y > SettingsButtonRect.Top && mState.Y < SettingsButtonRect.Bottom)
            {
                SettingsButton = contents.Load<Texture2D>(@"images/Buttons/SettingsHover");
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Arktet.gameState = Arktet.GameState.settings;
                }
            }
            else
            {
                SettingsButton = contents.Load<Texture2D>(@"images/Buttons/Settings");
            }

            if (mState.X > ExitButtonRect.Left && mState.X < ExitButtonRect.Right &&
                 mState.Y > ExitButtonRect.Top && mState.Y < ExitButtonRect.Bottom)
            {
                ExitButton = contents.Load<Texture2D>(@"images/Buttons/ExitHover");
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                ExitButton = contents.Load<Texture2D>(@"images/Buttons/Exit");
            }
            OldmState = mState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(titlebg, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(PlayButton, PlayButtonRect, Color.White);
            spriteBatch.Draw(SettingsButton, SettingsButtonRect, Color.White);
            spriteBatch.Draw(ExitButton, ExitButtonRect, Color.White);
        }
    }
}
