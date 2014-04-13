using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class Tetris
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);
        private Paddle paddle;
        private Ball ball;
        private Array BlocksArray;
        private Random rand;
        private Blocks blocks;
        private ContentManager content;
        private SpriteFont arial;
        public List<Blocks> BlocksList;
        public List<OldBlocks> OldBlockList;
        public int TetScore, ArkScore;
        public int RandomBlock;
        public bool TetDone;
        
        
         public Tetris(ContentManager c, Paddle p, Ball b)
        {
            BlocksArray = new string[]{ "BackLForm", "BackZForm", "IForm",  "SquareForm", "TForm", "ZForm", "LForm"};
            content = c;
            this.BlocksList = new List<Blocks>();
            blocks = new Blocks(content, "BackZForm", Color.White, this, b);
            ball = b;
            paddle = p;
            this.arial = content.Load<SpriteFont>("arialscore");
            rand = new Random();
            this.TetDone = false;
            this.OldBlockList = new List<OldBlocks>();
        }

         public void GetNewBlock()
         {
             RandomBlock = rand.Next(0, 7);
             TetScore = TetScore + 350;
             blocks = new Blocks(content, BlocksArray.GetValue(RandomBlock).ToString(), Color.White, this, ball);
         }

         public void Update(GameTime gt)
         {
             for (int i = 0; i < OldBlockList.Count; i++)
             {
                 if(this.OldBlockList[i].blockRect.Intersects(ball.bYGet)){
                    // MessageBox(new IntPtr(0), "Yep Intersected", "Yep", 0);
                     this.OldBlockList.Remove(this.OldBlockList[i]);
                     if (ball.directionGet == 1)
                     {
                         ball.direction = 0;
                     }
                     else if (ball.directionGet == 0)
                     {
                         ball.direction = 1;
                     }
                     ArkScore = ArkScore + 400;
                 }
                 if (this.OldBlockList.Count == 0)
                 {
                     Arktet.gameState = Arktet.GameState.gameover;
                 }
             }
             this.blocks.Update();
         }

         public void Draw(SpriteBatch sb)
         {
             this.blocks.Draw(sb);
             sb.DrawString(this.arial, "Score: " + ArkScore.ToString(), new Vector2(930, 670), Color.White);
             sb.DrawString(this.arial, "Score: " + TetScore.ToString(), new Vector2(220, 670), Color.White);
             //sb.Draw(BackL, Forms, Color.White);
           //  blocks.Draw(sb);
         }
    }
}
