using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    class EmptyCell : Cell
    {
        public int NearMinesNumber { get; set; }

        private SpriteFont _textFont;

        public EmptyCell(Texture2D cellBackGroundTexture, SpriteFont textFont) : base(cellBackGroundTexture)
        {
            _textFont = textFont;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
