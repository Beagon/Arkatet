using System;

namespace Project_Dustcrazy
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Arktet game = new Arktet())
            {
                game.Run();
            }
        }
    }
#endif
}

