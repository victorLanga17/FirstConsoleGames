/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class with the code of the game Snake
 */

using System;

namespace CommandLineGames
{
    internal class Snake
    {
        internal void MenuSnake()
        {
            bool end = false;
            do
            {
                PrintTitleScreen();
                ChooseOption(ref end);
            } while (!end);
        }

        private void PrintTitleScreen()
        {
            Console.WriteLine("");
        }

        private void ChooseOption(ref bool end)
        {
            int option = Convert.ToInt32(InData.GetString("PROVISIONAL 1, 2 o 3"));
            switch (option)
            {
                case 1:
                    SnakeGame(ChooseLevelSize());
                    break;
                case 2:
                    break;
                default:
                    end = true;
                    break;
            }
        }

        private int ChooseLevelSize()
        {
            int levelSize = Convert.ToInt32(InData.GetString("PROVISIONAL 10, 20 o 30"));
            return levelSize;
        }

        private void SnakeGame(int levelSize)
        {
            string[] snake = {"⏹", "⏹", "⏹"};
            int[,] snakePosition =
            {
                {0, 0},
                {0, 1},
                {0, 2}
            } ;
            bool endOfTheGame = false;
            
            SnakeStart(levelSize);
            do
            {
                // GenerateObjective()
                // GetInput()
                // MoveSnake()
                // CheckIfEnd()
                
            } while (!endOfTheGame);
        }

        private void SnakeStart(int levelSize)
        {
            PrintLevel(levelSize);
            PrintInitialPosition(levelSize);
        }

        private void PrintLevel(int levelSize)
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

        private void PrintInitialPosition(int levelSize)
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
    }
}