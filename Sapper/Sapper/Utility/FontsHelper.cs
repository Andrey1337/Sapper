using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sapper.Utility
{
    static class FontsHelper
    {
        private static Dictionary<string, SpriteFont> _gameFonts;

        public static Dictionary<string, SpriteFont> LoadFonts(ContentManager contentManager)
        {
            if (_gameFonts == null)
                _gameFonts = new Dictionary<string, SpriteFont>();
            else
                return _gameFonts;

            _gameFonts.Add("defaultFont",contentManager.Load<SpriteFont>("defaultTextFont"));

            return _gameFonts;
        }

    }
}
