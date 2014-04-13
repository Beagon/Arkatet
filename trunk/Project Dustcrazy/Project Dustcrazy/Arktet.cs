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
using System.Media;

namespace Project_Dustcrazy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Arktet : Microsoft.Xna.Framework.Game
    {
        public enum GameState { title, settings, help, scores, game, gameover }
        public static GameState gameState = GameState.title;
        public int ScorePlayer1, ScorePlayer2;
        bool Shownscreen;
        int GameElapsed;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D titlebg, splashScreen;
        SpriteFont arial;
        Titlescreen TS;
        Game _game;
        Settings _Settings;
        GameOver _GameOver;
        MouseState mState, OldmState;
        Song bgMusic;
        public float volume;

        public Arktet()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            IsMouseVisible = true;
            Shownscreen = false;
        }


        protected override void Initialize()
        {
            _Settings = new Settings(Content, this);
            TS = new Titlescreen(Content);
            _game = new Game(Content);
            _GameOver = new GameOver(Content);
            //Music
            bgMusic = Content.Load<Song>(@"sound/maintheme");
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arial = Content.Load<SpriteFont>("arial");
            splashScreen = Content.Load<Texture2D>(@"images/Splashscreen");

            titlebg = Content.Load<Texture2D>(@"images/Backgrounds/titlescreen");
            volume = 0.5f;

            //Play Music
           // MediaPlayer.Play(this.bgMusic);
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = volume;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MediaPlayer.Volume = volume;
            ScorePlayer1 = _game.Score1;
            ScorePlayer2 = _game.Score2;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //Global Settings and update
            mState = Mouse.GetState();
            if (!Shownscreen)
            {
                GameElapsed = GameElapsed + gameTime.ElapsedGameTime.Milliseconds;
                if (GameElapsed >= 3000)
                {

                    Shownscreen = true;
                    splashScreen = Content.Load<Texture2D>(@"images/nothing");
                }
            }else{

                switch (gameState)
                {
                    case GameState.title:
                        TS.Update();
                        break;

                    case GameState.settings:
                        _Settings.Update();
                        break;

                    case GameState.game:
                        _game.Update(gameTime);
                        break;

                    case GameState.gameover:
                        _GameOver.Update(gameTime, ScorePlayer1, ScorePlayer2, this);
                        break;


                }
            }


            OldmState = mState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if(!Shownscreen){
                        spriteBatch.Draw(splashScreen, new Vector2(0, 0), Color.White);
            }else{
            switch (gameState)
            {
                case GameState.title:
                    TS.Draw(spriteBatch);
                    break;

                case GameState.settings:
                    _Settings.Draw(spriteBatch);
                    break;

                case GameState.game:
                    _game.Draw(spriteBatch);
                    break;

                case GameState.gameover:
                    _GameOver.Draw(spriteBatch);
                    break;


            }
            }
    //spriteBatch.DrawString(arial, GameElapsed.ToString(), new Vector2(0, 0), Color.White); 
 

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
