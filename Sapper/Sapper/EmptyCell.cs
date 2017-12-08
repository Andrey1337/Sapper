using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    class EmptyCell : Cell
    {
        public int NearMinesNumber { get; set; }

        private readonly SpriteFont _textFont;

        public EmptyCell(SapperGame game, Texture2D cellBackGroundTexture, SpriteFont textFont, Rectangle position, int boardPositionX, int boardPositionY) : base(game, cellBackGroundTexture, position, boardPositionX, boardPositionY)
        {
            _textFont = textFont;
        }

        public override void OnClick()
        {
            if (IsFlagOn) return;

            IsVisible = true;
            if (NearMinesNumber == 0 && SapperGame.IsGameStarted)
            {
                for (int k = -1; k < 2; k++)
                {
                    if (k + BoardPositionX < 0 || k + BoardPositionX >= SapperGame.Board.BoardMatrix.GetLength(0))
                        continue;
                    for (int l = -1; l < 2; l++)
                    {
                        if (l + BoardPositionY < 0 || l + BoardPositionY >= SapperGame.Board.BoardMatrix.GetLength(1) || k == 0 && l == 0)
                            continue;
                        if (!Board.BoardMatrix[k + BoardPositionX, l + BoardPositionY].IsVisible)
                            Board.BoardMatrix[k + BoardPositionX, l + BoardPositionY].OnClick();

                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(CellBackgroundTexture, PositionRectangle, Color.Gray);
                if (NearMinesNumber != 0)
                {
                    spriteBatch.DrawString(_textFont, NearMinesNumber.ToString(), new Vector2(PositionRectangle.X, PositionRectangle.Y), Color.Black);
                }
            }
            else
            {
                spriteBatch.Draw(CellBackgroundTexture, PositionRectangle, new Color(194, 194, 214));
                base.Draw(spriteBatch);
            }

        }
    }
}
