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
    public class Board
    {
        public Cell[,] BoardMatrix { get; }
        public int NumOfFlags { get; }

        private readonly SapperGame _sapperGame;

        public Board(SapperGame sapperGame, int lenght)
        {
            _sapperGame = sapperGame;
            BoardMatrix = new Cell[lenght, lenght];

            Rectangle position = new Rectangle(100, 200, 40, 40);

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    BoardMatrix[i, j] = new EmptyCell(_sapperGame, _sapperGame.GameTextures["cleanTexture"], _sapperGame.GameFonts["defaultFont"], position, i, j);
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
                int x = rnd.Next(BoardMatrix.GetLength(0));
                int y = rnd.Next(BoardMatrix.GetLength(1));
                while (x == i && y == j)
                {
                    x = rnd.Next(BoardMatrix.GetLength(0));
                    y = rnd.Next(BoardMatrix.GetLength(1));
                }

                Rectangle rect = BoardMatrix[x, y].PositionRectangle;
                BoardMatrix[x, y] = new MineCell(_sapperGame, _sapperGame.GameTextures["cleanTexture"], _sapperGame.GameTextures["mineTexture"], rect, x, y);
            }
        }

        private void CountAllCellsNearbyMines()
        {
            for (int i = 0; i < BoardMatrix.GetLength(0); i++)
            {
                if (i < 0 || i >= BoardMatrix.GetLength(0))
                    continue;
                for (int j = 0; j < BoardMatrix.GetLength(1); j++)
                {
                    if (j < 0 || j >= BoardMatrix.GetLength(1))
                        continue;
                    if (BoardMatrix[i, j].GetType() == typeof(MineCell))
                        continue;

                    for (int k = -1; k < 2; k++)
                    {
                        if (k + i < 0 || k + i >= BoardMatrix.GetLength(0))
                            continue;
                        for (int l = -1; l < 2; l++)
                        {
                            if (l + j < 0 || l + j >= BoardMatrix.GetLength(1))
                                continue;
                            if (BoardMatrix[i + k, j + l].GetType() == typeof(MineCell))
                                ((EmptyCell)BoardMatrix[i, j]).NearMinesNumber++;
                        }
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton != ButtonState.Pressed && mouseState.RightButton != ButtonState.Pressed)
                return;

            Point mousePoint = new Point(mouseState.X, mouseState.Y);

            for (int i = 0; i < BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < BoardMatrix.GetLength(1); j++)
                {
                    if (!BoardMatrix[i, j].PositionRectangle.Contains(mousePoint)) continue;

                    if (!_sapperGame.IsGameStarted)
                    {
                        StartGame(i, j);
                        CountAllCellsNearbyMines();
                        _sapperGame.IsGameStarted = true;
                    }
                    BoardMatrix[i, j].OnClick();

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < BoardMatrix.GetLength(1); j++)
                {
                    BoardMatrix[i, j].Draw(spriteBatch);
                }
            }
        }
    }
}
