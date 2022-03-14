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
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.WriteLine("\n\n\n\n                               Choose an option:");
            Console.WriteLine("\n                                        Play");
            Console.WriteLine("\n                                        Instructions");
            Console.WriteLine("\n                                        Exit\n\n\n\n\n\n");
            
            ExternalSources.AsciiElements.PrintSnakeDrawing();
        }

        internal static void PrintMenuCursor(int option)
        {
            int topPosition;
            if (option == 1) topPosition = 15;
            else if (option == 2) topPosition = 17;
            else topPosition = 19;

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(35, 15 + 2 * i);
                Console.Write(" ");
            }
            
            Console.SetCursorPosition(35, topPosition);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(">");
            Console.ResetColor();
        }
        
        internal static void PrintInstructions()
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 5, Console.CursorTop + 9);
            Console.WriteLine("Press the arrow keys to move the snake\n");
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 5, Console.CursorTop);
            Console.WriteLine("Eat the red apples to score one point\n");
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 5, Console.CursorTop);
            Console.WriteLine("Do not crash into the walls or yourself!\n");
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 6, 
                Console.WindowHeight / 2 + Console.WindowHeight / 3);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void PrintChooseDifficulty()
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.WriteLine("\n\n\n\n                               Choose a difficulty:");
            Console.WriteLine("\n                                        Easy");
            Console.WriteLine("\n                                        Medium");
            Console.WriteLine("\n                                        Hard\n\n\n\n\n\n");
            
            ExternalSources.AsciiElements.PrintSnakeDrawing();
        }

        internal static void PrintScore(int counter)
        {
            Console.SetCursorPosition(Console.WindowWidth - 20, Console.WindowHeight - 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score: ");
            Console.ResetColor();
            Console.Write(counter);
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
            if (!pointThisTurn)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + posToDelete[0] * 2,
                    Console.WindowHeight / 2 + posToDelete[1]);
                Console.WriteLine(" ");
            }
            else pointThisTurn = false;
            
            Console.SetCursorPosition(Console.WindowWidth/2 + snakePosition[0, 0] * 2, 
                Console.WindowHeight/2 + snakePosition[0, 1]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▀");
            Console.ResetColor();
        }
        
        internal static void EndScreen(bool isVictory, int counter)
        {
            Console.Clear();
            Console.SetCursorPosition(0, Console.WindowHeight / 2 - Console.WindowHeight / 3);
            if (isVictory) ExternalSources.AsciiElements.PrintSnakeVictory();
            else
            {
                ExternalSources.AsciiElements.PrintSnakeDefeat();
                Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 4 + 5, 
                    Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (counter == 0) Console.WriteLine("The snake couldn't eat any apple");
                else
                {
                    Console.Write("The snake could just eat {0} apple", counter);
                    if (counter > 1) Console.Write("s");
                }
                Console.ResetColor();
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - Console.WindowWidth / 4,
                    Console.WindowHeight / 2 + Console.WindowHeight / 3);
            Console.WriteLine("Press any key to return to the title screen");
            Console.ReadKey();
            Console.Clear();
        }
    }
}