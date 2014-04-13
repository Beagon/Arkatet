using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;



namespace Project_Dustcrazy
{
    public class Blocks
    {
        //Fields
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);
        private Texture2D blockText;
        private Rectangle blockRect;
        private Color kleur;
        private Ball ball;
        private ContentManager content;
        private KeyboardState kState, OkState;
        private Tetris tetris;
        private bool update = true, CantMoveRight = false, CantMoveLeft = false;
        private string IName, TextSide;
        private int Side, Count, Speed;
        private SpriteFont arial;
        // The color data for the images; used for per pixel collision
        private Color[] BlockTextureData;
        private Color[] OldBlockTextureData;


        //properties
        public Rectangle BlockRect
        {
            get { return this.blockRect; }
        }

        public int X_Rect
        {
            set { this.blockRect.X = value; }
        }
        
        public int Y_Rect
        {
            set { this.blockRect.Y = value; }
        }

        //Constructor
        public Blocks(ContentManager c, string ImageName, Color kleur, Tetris tet, Ball b)
        {
            this.content = c;
            this.blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + ImageName + "/Up");
            this.blockRect = new Rectangle(150, 0, blockText.Width, blockText.Height);
            this.IName = ImageName;
            this.kleur = kleur;
            this.Side = 1;
            this.TextSide = "Up";
            this.Speed = 1;
            this.arial = content.Load<SpriteFont>("arial");
            this.tetris = tet;
            this.ball = b;


            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
            this.blockText.GetData(BlockTextureData);
        }

        public void Update()
        {
            kState = Keyboard.GetState();
            //this.OldBlockList.Add(new OldBlocks(this.content, this.blockRect, this.IName, this.kleur));
            Count = tetris.BlocksList.Count;
            if (update == true)
            {
                if (blockRect.Bottom <= 638)
                {
                    blockRect.Y = blockRect.Y + this.Speed;
                    if (kState.IsKeyDown(Keys.S))
                    {
                        this.Speed = 5;
                    }
                    else
                    {
                        this.Speed = 1;
                    }
                    if(kState.IsKeyDown(Keys.Escape)){
                                         Arktet.gameState = Arktet.GameState.gameover;
                    }
                    if (kState.IsKeyDown(Keys.D) && blockRect.X <= 365 - blockText.Width && !CantMoveRight)
                    {
                        blockRect.X = blockRect.X + 5;
                    }
                    if (kState.IsKeyDown(Keys.A) && blockRect.X >= 5 && !CantMoveLeft)
                    {
                        blockRect.X = blockRect.X - 5;
                    }
                    if (kState.IsKeyDown(Keys.W) && OkState.IsKeyUp(Keys.W))
                    {
                        Side = Side + 1;
                        if (Side == 1)
                        {
                            blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/Up");
                            blockRect = new Rectangle(blockRect.X, blockRect.Y, blockText.Width, blockText.Height);
                            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
                            this.blockText.GetData(BlockTextureData);
                            TextSide = "Up";
                        }
                        if (Side == 2)
                        {
                            blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/Right");
                            blockRect = new Rectangle(blockRect.X, blockRect.Y, blockText.Width, blockText.Height);
                            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
                            this.blockText.GetData(BlockTextureData);
                            TextSide = "Right";
                        }
                        if (Side == 3)
                        {
                            blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/Down");
                            blockRect = new Rectangle(blockRect.X, blockRect.Y, blockText.Width, blockText.Height);
                            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
                            this.blockText.GetData(BlockTextureData);
                            TextSide = "Down";
                        }
                        if (Side == 4)
                        {
                            blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/Left");
                            blockRect = new Rectangle(blockRect.X, blockRect.Y, blockText.Width, blockText.Height);
                            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
                            this.blockText.GetData(BlockTextureData);
                            TextSide = "Left";
                        }
                        if (Side >= 5)
                        {
                            Side = 1;
                            blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/Up");
                            blockRect = new Rectangle(blockRect.X, blockRect.Y, blockText.Width, blockText.Height);
                            BlockTextureData = new Color[this.blockText.Width * this.blockText.Height];
                            this.blockText.GetData(BlockTextureData);
                            TextSide = "Up";
                        }

                        // hoek += 0.05f;
                    }
                }
                else
                {
                    tetris.OldBlockList.Add(new OldBlocks(content, this.blockRect, this.IName, this.TextSide, this.kleur));
                    //System.Threading.Thread.Sleep(100);
                    //System.Threading.Thread.Sleep(5000);
                    update = false;
                    if (this.BlockRect.Y > 0)
                    {
                        tetris.GetNewBlock();
                    }
                   // update = true;

                }

                for (int i = 0; i < tetris.OldBlockList.Count; i++)
                {

                    /*    if (tetris.OldBlockList[i].blockRect.Intersects(this.BlockRect) && this.BlockRect != tetris.OldBlockList[i].blockRect)
                        {

                            update = false;
                            tetris.OldBlockList.Add(new OldBlocks(this.content, this.blockRect, this.IName, this.TextSide, Color.Green));

                            if (this.BlockRect.Y > 5)
                            {
                                tetris.GetNewBlock();
                            }
                        }*/

                        OldBlockTextureData = new Color[tetris.OldBlockList[i].blockText.Width * tetris.OldBlockList[i].blockText.Height];
                        tetris.OldBlockList[i].blockText.GetData(OldBlockTextureData);
                        if (IntersectPixels(tetris.OldBlockList[i].blockRect, OldBlockTextureData,
                                        blockRect, BlockTextureData) && this.BlockRect != tetris.OldBlockList[i].blockRect)
                        {
                            if (this.blockRect.Left != tetris.OldBlockList[i].blockRect.Right)
                            {
                                if (this.blockRect.Right != tetris.OldBlockList[i].blockRect.Left)
                                {

                                    update = false;
                                    tetris.OldBlockList.Add(new OldBlocks(this.content, this.blockRect, this.IName, this.TextSide, Color.White));

                                    if (this.BlockRect.Y > 5)
                                    {
                                        tetris.GetNewBlock();
                                    }
                                    else
                                    {
                                        tetris.TetDone = true;
                                        blockText = content.Load<Texture2D>(@"images/nothing");
                                    }
                                }
                                else {
                                    CantMoveLeft = true;
                                }
                            }
                            else
                            {
                                CantMoveRight = true;
                            }
                        }
                    }

                }
            
            OkState = kState;
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < tetris.OldBlockList.Count; i++)
            {
                tetris.OldBlockList[i].Draw(sb);
            }
             //sb.DrawString(this.arial, tetris.OldBlockList.Count.ToString(), new Vector2(0, 0), Color.White);
            sb.Draw(this.blockText, this.blockRect, this.kleur);
        }


        static bool IntersectPixels(Rectangle rectangleA, Color[] dataA,
                                    Rectangle rectangleB, Color[] dataB)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
