using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper
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


            _gameTextures.Add("cellBackgroundTexture", CreateTexture(graphicsDevice));
            _gameTextures.Add("mineTexture", CreateTexture(graphicsDevice));

            return _gameTextures;

        }

        private static Texture2D CreateTexture(GraphicsDevice graphicsDevice)
        {
            return new Texture2D(graphicsDevice, 0, 0);
        }

    }
}
