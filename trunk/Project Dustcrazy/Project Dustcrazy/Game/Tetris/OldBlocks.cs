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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Project_Dustcrazy
{
    public class OldBlocks
    {
        //Fields
        public Rectangle blockRect;
        private String IName;
        public Texture2D blockText;
        private Color kleur;
        private ContentManager content;


        //properties
        public Rectangle BlockRect
        {
            get { return this.blockRect; }
        }

        //Constructor
        public OldBlocks(ContentManager c, Rectangle BlockRectangle, string name, string Side, Color Kleur)
        {
            this.IName = name;
            this.content = c;
            this.blockText = content.Load<Texture2D>(@"images/Game/Tetris/" + IName + "/" + Side);
            this.blockRect = BlockRectangle;
            this.kleur = Kleur;

            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(this.blockText, this.blockRect, this.kleur);
        }
    }
}
