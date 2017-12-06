using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper.Utility
{
    static class TexturesHelper
    {
        private static Dictionary<string, Texture2D> _gameTextures;

        public static Dictionary<string, Texture2D> LoadTextures(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            if (_gameTextures == null)
                _gameTextures = new Dictionary<string, Texture2D>();
            else
                return _gameTextures;


            //_gameTextures.Add("cleanTexture", CreateTexture(graphicsDevice));
            _gameTextures.Add("cleanTexture", contentManager.Load<Texture2D>("cleanTexture"));
            _gameTextures.Add("mineTexture", contentManager.Load<Texture2D>("mineTexture"));

            return _gameTextures;

        }

        private static Texture2D CreateTexture(GraphicsDevice graphicsDevice)
        {
            return new Texture2D(graphicsDevice, 1, 1);
        }

    }
}
