/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where are the output methods are managed
 */

using System;

namespace CommandLineGames
{
    public static class OutDataSnake
    {
        internal static void PrintTitleScreen()
        {
            Console.WriteLine("");
        }
        
        internal static void PrintLevel(int levelSize)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 - levelSize, Console.WindowHeight/2 - levelSize/2);

            for (int i = 0; i < 2; i++)
            {
                
                int leftOrRight = 1; // right = 1, left = -3
                if (i == 1) leftOrRight = -3;
                for (int j = 0; j < levelSize; j++)
                {
                    Console.Write("▀");
                    Console.SetCursorPosition(Console.CursorLeft + leftOrRight, Console.CursorTop);
                }

                int topOrBottom = 1; // top = -1, bottom = 1
                if (i == 1) topOrBottom = -1;
                for (int k = 0; k < levelSize; k++)
                {
                    Console.Write("▀");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + topOrBottom);
                }
            }
        }
        
        internal static void PrintInitialPosition(int levelSize)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 + 4 * (levelSize / 10) /*I like this start*/,
                Console.WindowHeight/2);

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 3 /*= Length of the snake at the start*/; i++)
            {
                Console.Write("▀");
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            }
            Console.ResetColor();
        }
        
        internal static void PrintNewObjective(int[] objectivePosition)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 + objectivePosition[0] * 2,
                Console.WindowHeight/2 + objectivePosition[1]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▀");
            Console.ResetColor();
        }
        
        internal static void PrintNewTurn(ref bool pointThisTurn, int[,] snakePosition, int[] posToDelete)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 + snakePosition[0, 0] * 2, 
                Console.WindowHeight/2 + snakePosition[0, 1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▀");
            Console.ResetColor();

            if (!pointThisTurn)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + posToDelete[0] * 2,
                    Console.WindowHeight / 2 + posToDelete[1]);
                Console.WriteLine(" ");
            }
            else pointThisTurn = false;
        }
    }
}