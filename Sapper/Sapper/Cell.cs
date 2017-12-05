using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    abstract class Cell
    {
        protected Texture2D CellBackgroundTexture;

        protected bool IsVisible;

        public Rectangle PositionRectangle { get; }

        protected Cell(Texture2D cellBackGroundTexture, Rectangle position)
        {
            CellBackgroundTexture = cellBackGroundTexture;
            PositionRectangle = position;
        }
        public Rectangle Rectangle { get; protected set; }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
