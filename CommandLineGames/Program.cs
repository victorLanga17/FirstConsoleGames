/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where the program starts working
 */

using System;

namespace CommandLineGames
{
    /// <summary>
    /// Class where the program starts working
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method where some console parameters are defined
        /// </summary>
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Command Line Games by Victor Langa";
            if (OperatingSystem.IsWindows())
                ExternalSources.DisableConsoleResize.SetDisableResize();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING");
                Console.ResetColor();
                Console.WriteLine("\nThe program has detected your operating system is not Windows." +
                                  "\nTo assure the program works properly, the console must be maximized and not " +
                                  "resized or minimized during its execution.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n -- Press any key to continue");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            
            var program = new Program();
            program.Start();
        }

        /// <summary>
        /// Method that starts the loop of the program
        /// </summary>
        private void Start()
        {
            bool end = false;

            do
            {
                PrintMenu();
                ChooseOption(ref end);
            } while (!end);
        }

        /// <summary>
        /// Method that prints the main menu
        /// </summary>
        private void PrintMenu()
        {
            Console.WriteLine("Command Line Games");
            Console.WriteLine("By Victor Langa");
            Console.WriteLine("\n   [1] Snake" +
                              "\n   [2] Minesweeper" +
                              "\n   [5] Exit");
        }

        /// <summary>
        /// Method to choose an option from the main menu
        /// </summary>
        /// <param name="end">Boolean that determains if the program shall end</param>
        private void ChooseOption(ref bool end)
        {
            char option = InData.GetChar("\n--- Introduce an option or press any other key to exit");
            bool isValidOption;

            do
            {
                isValidOption = true;
                switch (option)
                {
                    case '1':
                        ExecuteSnake();
                        break;
                    case '2':
                        ExecuteMinesweeper();
                        break;
                    case '5':
                        end = true;
                        break;
                    default:
                        isValidOption = false;
                        option = InData.GetChar("\n\nIntroduce a valid option:");
                        break;
                }
            } while (!isValidOption);
        }

        /// <summary>
        /// Method where the game snake is executed
        /// </summary>
        private void ExecuteSnake()
        {
            Console.Clear();
            var snakeGame = new Snake();
            snakeGame.MenuSnake();
            Console.Clear();
        }

        /// <summary>
        /// Method where the game snake is executed
        /// </summary>
        private void ExecuteMinesweeper()
        {
            Console.Clear();
            var minesweeperGame = new Minesweeper();
            minesweeperGame.MinesweeperMain();
            Console.Clear();
        }
    }
}