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
        private readonly SapperGame _sapperGame;
        private bool _isExploded;
        public MineCell(Texture2D cellBackGroundTexture, Texture2D mineTexture, Rectangle position, SapperGame sapperGame) : base(cellBackGroundTexture, position)
        {
            _mineTexture = mineTexture;
            _sapperGame = sapperGame;
        }

        public override void OnClick()
        {
            _sapperGame.LoseGame();
            _isExploded = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_isExploded)
            {
                spriteBatch.Draw(CellBackgroundTexture, Rectangle, Color.Red);
                spriteBatch.Draw(_mineTexture, Rectangle, Color.White);
                return;
            }

            if (IsVisible)
            {
                spriteBatch.Draw(CellBackgroundTexture, Rectangle, Color.Blue);
                spriteBatch.Draw(_mineTexture, Rectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(CellBackgroundTexture, Rectangle, Color.Blue);
            }
        }
    }
}
