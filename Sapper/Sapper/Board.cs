using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sapper
{
    class Board
    {
        readonly Cell[,] _board;
        public int NumOfFlags { get; }

        private readonly SapperGame _sapperGame;

        public Board(SapperGame sapperGame, int lenght)
        {
            _sapperGame = sapperGame;
            _board = new Cell[lenght, lenght];

            Rectangle position = new Rectangle(100, 200, 20, 20);

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    _board[i, j] = new EmptyCell(_sapperGame.GameTextures["cleanTexture"], _sapperGame.GameFonts["defaultFont"], position);
                    position.X += position.Width + 1;
                }
                position.X = 100;
                position.Y += position.Height + 1;
            }

            NumOfFlags = lenght;
        }

        public void StartGame(int i, int j)
        {
            Random rnd = new Random();
            for (int k = 0; k < _sapperGame.MinesNum; k++)
            {
                int x = rnd.Next(_board.GetLength(0));
                int y = rnd.Next(_board.GetLength(1));
                while ((x == i && y == j) || _board[i, j].GetType() == typeof(MineCell))
                {
                    x = rnd.Next(_board.GetLength(0));
                    y = rnd.Next(_board.GetLength(1));
                }

                EmptyCell temp = (EmptyCell)_board[i, j];
                _board[i, j] = new MineCell(_sapperGame.GameTextures["cleanTexture"], _sapperGame.GameTextures["mineTexture"], temp.Rectangle, _sapperGame);
            }
        }

        private void CountAllCellsNearbyMines()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (i < 0 || i >= _board.GetLength(0))
                    continue;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (j < 0 || j >= _board.GetLength(1))
                        continue;
                    if (_board[i, j].GetType() == typeof(MineCell))
                        continue;

                    for (int k = -1; k < 2; k++)
                    {
                        if (k + i < 0 || k + i >= _board.GetLength(0))
                            continue;
                        for (int l = -1; l < 2; l++)
                        {
                            if (l + j < 0 || l + j >= _board.GetLength(1))
                                continue;
                            if (_board[i + k, j + l].GetType() == typeof(MineCell))
                                ((EmptyCell)_board[i, j]).NearMinesNumber++;
                        }
                    }
                }
            }
        }



        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton != ButtonState.Pressed)
                return;

            Point mousePoint = new Point(mouseState.X, mouseState.Y);

            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j].Rectangle.Contains(mousePoint))
                    {
                        _board[i, j].OnClick();
                        if (_sapperGame.isGameStarted) continue;
                        StartGame(i, j);
                        CountAllCellsNearbyMines();
                        _sapperGame.isGameStarted = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i, j].Draw(spriteBatch);
                }
            }
        }
    }
}
