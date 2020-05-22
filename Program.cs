using System;

namespace examination_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Start game with number of players (1-40)
                Game game = new Game(25);
                game.Play();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
