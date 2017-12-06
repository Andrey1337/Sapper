using System;
using System.Collections.Generic;
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
    public class SapperGame : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private ContentManager _contentManager;

        public Dictionary<string, Texture2D> GameTextures { get; private set; }
        public Dictionary<string, SpriteFont> GameFonts { get; private set; }

        public bool isGameStarted { get; set; }

        private TimeSpan _inGameTime;

        private Board _board;

        public int MinesNum { get; private set; }

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
            _board = new Board(this, 8);
            _inGameTime = new TimeSpan();
        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isGameStarted)
                _inGameTime += gameTime.ElapsedGameTime;

            _board.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Cyan);
            _board.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
