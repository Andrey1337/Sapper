using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
{
    class MineCell : Cell
    {
        private readonly Texture2D _mineTexture;

        private bool _isExploded;
        public MineCell(SapperGame game, Texture2D cellBackGroundTexture, Texture2D mineTexture, Rectangle position, int boardPositionX, int boardPositionY) : base(game, cellBackGroundTexture, position, boardPositionX, boardPositionY)
        {
            _mineTexture = mineTexture;
        }

        public override void OnClick()
        {
            SapperGame.LoseGame();
            _isExploded = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isExploded)
            {
                spriteBatch.Draw(CellBackgroundTexture, PositionRectangle, Color.Red);
                spriteBatch.Draw(_mineTexture, PositionRectangle, Color.White);
                return;
            }

            if (IsVisible)
            {
                spriteBatch.Draw(CellBackgroundTexture, PositionRectangle, new Color(194, 194, 214));
                spriteBatch.Draw(_mineTexture, PositionRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(CellBackgroundTexture, PositionRectangle, new Color(194, 194, 214));
            }
        }
    }
}
