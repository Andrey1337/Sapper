using System;

namespace Sapper
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SapperGame game = new SapperGame())
            {
                game.Run();
            }
        }
    }
#endif
}

