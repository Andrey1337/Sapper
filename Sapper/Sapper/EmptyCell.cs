using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    class EmptyCell : Cell
    {
        public int NearMinesNumber { get; set; }

        private readonly SpriteFont _textFont;

        public EmptyCell(Texture2D cellBackGroundTexture, SpriteFont textFont, Rectangle position) : base(cellBackGroundTexture, position)
        {
            _textFont = textFont;
        }

        public override void OnClick()
        {
            IsVisible = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw((Texture2D) CellBackgroundTexture, (Rectangle) Rectangle, Color.Gray);
                if (NearMinesNumber != 0)
                {
                    spriteBatch.DrawString(_textFont, NearMinesNumber.ToString(), new Vector2(Rectangle.X, Rectangle.Y), Color.Black);
                }
            }
            else
            {
                Debug.WriteLine("DRAW");
                spriteBatch.Draw((Texture2D) CellBackgroundTexture, (Rectangle) Rectangle, Color.Black);
            }

        }
    }
}
