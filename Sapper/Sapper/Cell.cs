using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    public abstract class Cell
    {
        protected Texture2D CellBackgroundTexture;

        public bool IsVisible { get; protected set; }

        protected SapperGame SapperGame;

        protected Board Board => SapperGame.Board;

        protected int BoardPositionX { get; }
        protected int BoardPositionY { get; }
        public bool IsFlagOn { get; set; }

        public Rectangle PositionRectangle { get; }

        protected Cell(SapperGame sapperGame, Texture2D cellBackGroundTexture, Rectangle position, int boardPositionX, int boardPositionY)
        {
            SapperGame = sapperGame;
            CellBackgroundTexture = cellBackGroundTexture;
            PositionRectangle = position;
            BoardPositionX = boardPositionX;
            BoardPositionY = boardPositionY;
        }

        public abstract void OnClick();

        public void OnRightClick()
        {
            IsFlagOn = !IsFlagOn;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsFlagOn)
            {
                spriteBatch.Draw(SapperGame.GameTextures["flagTexture"], new Rectangle(PositionRectangle.X + 10, PositionRectangle.Y + 10, PositionRectangle.Width - 20, PositionRectangle.Height - 20), Color.White);
            }
        }

    }
}
