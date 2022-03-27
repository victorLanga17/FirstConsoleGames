/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where are the output methods are managed
 */

using System;
using System.Threading;

namespace CommandLineGames
{
    /// <summary>
    /// Class where the general output methods are managed
    /// </summary>
    public static class OutData
    {
        /// <summary>
        /// Method that displays the menu cursor in the corresponding position
        /// </summary>
        /// <param name="option">Last option (or position) recorded before the method was executed</param>
        /// <param name="leftPosition">Int with the horizontal position the console cursor will be set</param>
        /// <param name="topPosition">Int with the vertical position the console cursor will be set</param>
        /// <param name="numberOfOptions">Int with the number of menu options</param>
        internal static void PrintMenuCursor(int option, int leftPosition, int topPosition, int numberOfOptions)
        {
            topPosition -= 2; // this is to match the Console.SetCursorPosition with the for's structure
            int currentPosition = topPosition + 2 * option;

            for (int i = 1; i <= numberOfOptions; i++)
            {
                Console.SetCursorPosition(leftPosition, topPosition + 2 * i);
                Console.Write(" ");
            }
            
            Console.SetCursorPosition(leftPosition, currentPosition);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(">");
            Console.ResetColor();
        }

        /// <summary>
        /// Method that clears the menu cursor possible positions
        /// </summary>
        /// <param name="leftPosition">Int with the horizontal position the console cursor will be set</param>
        /// <param name="topPosition">Int with the vertical position the console cursor will be set</param>
        /// <param name="numberOfOptions">Int with the number of menu options</param>
        internal static void ClearMenuCursor(int leftPosition, int topPosition, int numberOfOptions)
        {
            topPosition -= 2;
            for (int i = 1; i <= numberOfOptions; i++)
            {
                Console.SetCursorPosition(leftPosition, topPosition + 2 * i);
                Console.Write(" ");
            }
        }
    }
    
    /// <summary>
    /// Class where the specific output methods for the game Snake are managed
    /// </summary>
    public static class OutDataSnake
    {
        /// <summary>
        /// Method that prints the title screen
        /// </summary>
        internal static void PrintTitleScreen()
        {
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.CursorTop + 3);
            Console.WriteLine("Choose an option:");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Play");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Instructions");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Exit");
            
            ExternalSources.AsciiElements.PrintSnakeDrawing();
        }

        /// <summary>
        /// Method that prints the instructions
        /// </summary>
        internal static void PrintInstructions()
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop + 9);
            Console.WriteLine("Press the arrow keys to move the snake");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop + 1);
            Console.WriteLine("Eat the red apples to score one point");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.CursorTop + 1);
            Console.WriteLine("Do not crash into the walls or yourself!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 
                Console.WindowHeight / 2 + Console.WindowHeight / 3);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Method that prints the difficulty menu
        /// </summary>
        internal static void PrintChooseDifficulty()
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.CursorTop + 3);
            Console.WriteLine("Choose a difficulty:");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Easy");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Medium");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.CursorTop + 1);
            Console.WriteLine("Hard");
            
            ExternalSources.AsciiElements.PrintSnakeDrawing();
        }

        /// <summary>
        /// Method that prints the score during the game
        /// </summary>
        /// <param name="counter">Int with the score</param>
        internal static void PrintScore(int counter)
        {
            Console.SetCursorPosition(Console.WindowWidth - 20, Console.WindowHeight - 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Score: ");
            Console.ResetColor();
            Console.Write(counter);
        }
        
        /// <summary>
        /// Method that prints the level or board
        /// </summary>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
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
        
        /// <summary>
        /// Method that prints the initial position of the snake
        /// </summary>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
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
        
        /// <summary>
        /// Method that prints a new objective
        /// </summary>
        /// <param name="objectivePosition">Integer array with the new position</param>
        internal static void PrintNewObjective(int[] objectivePosition)
        {
            Console.SetCursorPosition(Console.WindowWidth/2 + objectivePosition[0] * 2,
                Console.WindowHeight/2 + objectivePosition[1]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("▀");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Method that prints the new position of the snake each turn
        /// </summary>
        /// <param name="pointThisTurn">Boolean that shows if a point was taken during the turn analyzed</param>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <param name="posToDelete">Integral array with the last position occupied by the snake</param>
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
        
        /// <summary>
        /// Method that prints the end screen
        /// </summary>
        /// <param name="isVictory">Boolean that determines if the game was won or lost</param>
        /// <param name="counter">Int with the score</param>
        internal static void EndScreen(bool isVictory, int counter)
        {
            Console.Clear();
            Console.SetCursorPosition(0, Console.WindowHeight / 2 - Console.WindowHeight / 3);
            if (isVictory) ExternalSources.AsciiElements.PrintSnakeVictory();
            else
            {
                ExternalSources.AsciiElements.PrintSnakeDefeat();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 
                    Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (counter == 0)
                {
                    Console.WriteLine("The snake couldn't eat any apple");
                }
                else
                {
                    Console.Write("The snake could just eat {0} apple", counter);
                    if (counter > 1) Console.Write("s");
                }
                Console.ResetColor();
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 25,
                    Console.WindowHeight / 2 + Console.WindowHeight / 3);
            Console.WriteLine("Press any key to return to the title screen");
            Console.ReadKey();
            Console.Clear();
        }
    }

    /// <summary>
    /// Class where the specific output methods for the game Minesweeper are managed
    /// </summary>
    public static class OutDataMinesweeper
    {
        /// <summary>
        /// Method that prints the title screen
        /// </summary>
        internal static void PrintTitleScreen()
        {
            while (!Console.KeyAvailable)
            {
                if (Console.KeyAvailable) continue;
                Console.Clear();
                ExternalSources.AsciiElements.PrintMinesweeperTitle();
                ExternalSources.AsciiElements.PrintMinesweeperMineDrawing();
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 4,
                    Console.WindowHeight - Console.WindowHeight / 4);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press any key to start");
                Console.ResetColor();
                Thread.Sleep(1000);
                
                if (Console.KeyAvailable) continue;
                Console.Clear();
                ExternalSources.AsciiElements.PrintMinesweeperTitle();
                ExternalSources.AsciiElements.PrintMinesweeperBoom();
                Console.SetCursorPosition(Console.WindowWidth - Console.WindowWidth / 4,
                    Console.WindowHeight - Console.WindowHeight / 4);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press any key to start");
                Console.ResetColor();
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Method that prints the instructions
        /// </summary>
        internal static void PrintInstructions()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 14);
            Console.WriteLine("Use the arrow keys to move");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 16);
            Console.WriteLine("Press [SPACEBAR] to reveal the square");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 18);
            Console.WriteLine("Press [ENTER] to put a flag");
        }

        /// <summary>
        /// Method that prints the needed input to enter the menu
        /// </summary>
        internal static void PrintHowToEnterMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 24);
            Console.WriteLine("Press [M] to enter the menu");
        }
        
        /// <summary>
        /// Method that prints the menu
        /// </summary>
        internal static void PrintMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 24);
            Console.WriteLine("     Return to the game    ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 20, 26);
            Console.WriteLine("Difficulty");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 20, 28);
            Console.WriteLine("Exit");
        }

        /// <summary>
        /// Method that clears the menu when closed
        /// </summary>
        internal static void ClearMenu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 - 25, 24);
            Console.WriteLine("Press [M] to enter the menu");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 20, 26);
            Console.WriteLine("          ");
            Console.SetCursorPosition(Console.WindowWidth / 4 - 20, 28);
            Console.WriteLine("    ");
        }

        /// <summary>
        /// Method that prints the minesweeper board
        /// </summary>
        internal static void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 4 + i + 2);
                for (int j = 0; j < 30; j++)
                    Console.Write("■ ");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Method that prints the difficulty options
        /// </summary>
        internal static void PrintDifficultyOptions()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4, 26);
            Console.WriteLine("Easy");
            Console.SetCursorPosition(Console.WindowWidth / 4, 28);
            Console.WriteLine("Normal");
            Console.SetCursorPosition(Console.WindowWidth / 4, 30);
            Console.WriteLine("Hard");
        }

        /// <summary>
        /// Method that clears the difficulty options when closed
        /// </summary>
        internal static void ClearDifficultyOptions()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4, 26);
            Console.WriteLine("    ");
            Console.SetCursorPosition(Console.WindowWidth / 4, 28);
            Console.WriteLine("      ");
            Console.SetCursorPosition(Console.WindowWidth / 4, 30);
            Console.WriteLine("    ");
        }

        /// <summary>
        /// Method that prints if the game is gonna change difficulty in the next game
        /// </summary>
        internal static void PrintNextGameDifficulty()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 + 33, Console.WindowHeight / 4 + 28);
            Console.WriteLine("Your difficulty options will be applied in the next game");
        }

        /// <summary>
        /// Method that clears the text that tells if the difficulty will change in the next game
        /// </summary>
        internal static void ClearNextGameDifficulty()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 + 33, Console.WindowHeight / 4 + 28);
            Console.WriteLine("                                                        ");
        }

        /// <summary>
        /// Method that prints a flag
        /// </summary>
        internal static void PrintPutFlag()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("▲");
            Console.ResetColor();
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        /// <summary>
        /// Method that prints a box when a flag was previously placed
        /// </summary>
        internal static void PrintQuitFlag()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("■");
            Console.ResetColor();
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        /// <summary>
        /// Method that prints the box value
        /// </summary>
        /// <param name="value">String with the box value</param>
        internal static void PrintBoxValue(string value)
        {
            if (value == "∅") Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }

        /// <summary>
        /// Method that prints the defeat
        /// </summary>
        internal static void PrintDefeat()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 + 15, Console.WindowHeight / 4 + 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost...");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Method that prints the win
        /// </summary>
        internal static void PrintWin()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 + 15, Console.WindowHeight / 4 + 24);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You won!");
            Console.ResetColor();
        }
        
        /// <summary>
        /// Method that clears the win or defeat
        /// </summary>
        internal static void ClearWinOrDefeat()
        {
            Console.SetCursorPosition(Console.WindowWidth / 4 + 15, Console.WindowHeight / 4 + 24);
            Console.WriteLine("           ");
            Console.SetCursorPosition(Console.WindowWidth / 4 + 15, Console.WindowHeight / 4 + 26);
            Console.WriteLine("                                    ");
        }
    }
}