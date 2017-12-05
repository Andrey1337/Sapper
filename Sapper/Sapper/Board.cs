using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sapper
{
    class Board
    {
        Cell[,] _board;
        public int NumOfFlags { get; }
        private bool _isGameStarted;

        public Board(int lenght)
        {
            _board = new Cell[lenght, lenght];

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    _board[i, j] = new EmptyCell();
                }
            }

            NumOfFlags = lenght;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            Point mousePoint = new Point(mouseState.X, mouseState.Y);

        }

        public void StartGame()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cell in _board)
            {
                cell.Draw(spriteBatch);
            }
        }
    }
}
