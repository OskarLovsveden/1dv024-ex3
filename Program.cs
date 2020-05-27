/// <summary>
/// https://www.exceptionnotfound.net/modeling-practice-uno-in-c-sharp-part-one-rules-assumptions-cards/
/// Used this for inspiration on creating cards/decks
/// </summary>

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
                Game game = new Game(40);
                game.Play();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
