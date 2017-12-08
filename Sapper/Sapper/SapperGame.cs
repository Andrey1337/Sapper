using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sapper
{
    public class SapperGame : Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private ContentManager _contentManager;

        public Dictionary<string, Texture2D> GameTextures { get; private set; }
        public Dictionary<string, SpriteFont> GameFonts { get; private set; }

        public bool IsGameStarted { get; set; }

        public bool IsGameLost { get; set; }
        public bool IsGameWin { get; set; }

        private TimeSpan _inGameTime;

        public Board Board { get; set; }

        public SapperGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 900;
            IsMouseVisible = true;
        }

        public void LoseGame()
        {
            IsGameLost = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            GameFonts = Utility.FontsHelper.LoadFonts(Content);
            GameTextures = Utility.TexturesHelper.LoadTextures(GraphicsDevice, Content);

            Board = new Board(this, 8, 8);
            _inGameTime = new TimeSpan();
        }

        public void WinGame()
        {
            IsGameWin = true;
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (IsGameLost || IsGameWin)
                return;

            if (IsGameStarted)
                _inGameTime += gameTime.ElapsedGameTime;

            Board.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(new Color(237, 236, 240));
            Board.Draw(_spriteBatch);
            _spriteBatch.DrawString(GameFonts["defaultFont"], Board.NumOfFlags.ToString(), new Vector2(100, 100), Color.Black);
            if (IsGameWin)
                _spriteBatch.DrawString(GameFonts["defaultFont"], "You win the game", new Vector2(200, 100), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
