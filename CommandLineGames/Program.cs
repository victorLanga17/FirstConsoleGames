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
            Console.CursorVisible = false;
            Console.Title = "Command Line Games by Victor Langa";
            if (OperatingSystem.IsWindows())
                ExternalSources.DisableConsoleResize.SetDisableResize();
            
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
                              "\n   [2] Minesweeper");
        }

        /// <summary>
        /// Method to choose an option from the main menu
        /// </summary>
        /// <param name="end">Boolean that determains if the program shall end</param>
        private void ChooseOption(ref bool end)
        {
            char option = InData.GetChar("\n--- Introduce an option or press any other key to exit");
            switch (option)
            {
                case '1':
                    ExecuteSnake();
                    break;
                case '2':
                    ExecuteMinesweeper();
                    break;
                default:
                    end = true;
                    break;
            }
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
            minesweeperGame.MenuMinesweeper();
            Console.Clear();
        }
    }
}