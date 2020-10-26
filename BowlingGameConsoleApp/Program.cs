using System;
using BowlingBall;

namespace BowlingGameConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowlling Game Started!");

            int[] X = new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 };// 94)]
            int[] Y = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 };//, 155)]
            int[] Z = new int[] { 5, 5, 10, 10, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 };// 136)]

            Game game1 = new Game();

            for (int i = 0; i < X.Length; i++)
            {
                game1.Roll(X[i]);
            }

            Console.WriteLine("Rolls Data:{ 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }");
            Console.WriteLine("Expected is 94");
            Console.WriteLine("Actual is {0}", game1.GetScore());

            Game game2 = new Game();
            for (int i = 0; i < Y.Length; i++)
            {
                game2.Roll(Y[i]);
            }

            Console.WriteLine("Rolls Data:{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }");
            Console.WriteLine("Expected is 155");
            Console.WriteLine("Actual is {0}", game2.GetScore());

            Game game3 = new Game();
            for (int i = 0; i < Z.Length; i++)
            {
                game3.Roll(Z[i]);
            }

            Console.WriteLine("Rolls Data:{ 5, 5, 10, 10, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 }");
            Console.WriteLine("Expected is 136");
            Console.WriteLine("Actual is {0}", game3.GetScore());
        }
    }
}
