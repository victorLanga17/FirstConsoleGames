/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where are the input methods are managed
 */

using System;
using System.Threading;

namespace CommandLineGames
{
    /// <summary>
    /// Class where the main input methods are managed
    /// </summary>
    public static class InData
    {
        /// <summary>
        /// Method that gets a char input and returns it
        /// </summary>
        /// <param name="message">Text that will be shown for the user</param>
        /// <returns>Input char</returns>
        public static char GetChar(string message)
        {
            Console.WriteLine(message);
            return Console.ReadKey(true).KeyChar;
        }

        /// <summary>
        /// Method that determines the option taken in the menu
        /// </summary>
        /// <param name="numberOfOptions">Int with the number of menu options</param>
        /// <param name="leftPosition">Int with the horizontal position the console cursor will be set</param>
        /// <param name="topPosition">Int with the vertical position the console cursor will be set</param>
        /// <returns>Int with the option taken</returns>
        internal static int GetMenuOption(int numberOfOptions, int leftPosition, int topPosition)
        {
            int option = 1;
            bool end = false;

            while (!end)
            {
                OutData.PrintMenuCursor(option, leftPosition, topPosition, numberOfOptions);
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.UpArrow)
                {
                    if (option == 1) option = numberOfOptions;
                    else option--;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (option == numberOfOptions) option = 1;
                    else option++;
                }
                else if (input.Key == ConsoleKey.Enter) end = true;
            }

            OutData.ClearMenuCursor(leftPosition, topPosition, numberOfOptions);
            return option;
        }
    }

    /// <summary>
    /// Class where the input methods exclusive to the game Snake are managed
    /// </summary>
    public static class InDataSnake
    {
        /// <summary>
        /// Method that determines the next direction the snake will be facing during the game
        /// </summary>
        /// <param name="lastInput">Last input registered before the execution of the method</param>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option</param>
        /// <returns>Int that represents the direction of the snake</returns>
        internal static int GetInput(int lastInput, int levelSize)
        {
            int timeout;
            switch (levelSize)
            {
                case 10:
                    timeout = 600;
                    break;
                case 20:
                    timeout = 400;
                    break;
                default:
                    timeout = 200;
                    break;
            }
            
            Thread.Sleep(timeout);
            
            while (!Console.KeyAvailable) return lastInput;

            int direction = lastInput;
            ConsoleKeyInfo newDirection = Console.ReadKey(true);
            
            switch (newDirection.Key)
            {
                case ConsoleKey.RightArrow:
                    direction = 1; //right
                    break;
                case ConsoleKey.LeftArrow:
                    direction = 2; //left
                    break;
                case ConsoleKey.UpArrow:
                    direction = 3; //up
                    break;
                case ConsoleKey.DownArrow:
                    direction = 4; //down
                    break;
            }

            while (Console.KeyAvailable) Console.ReadKey(true);
            
            if (lastInput == 1 && direction == 2 || lastInput == 2 && direction == 1 ||
                lastInput == 3 && direction == 4 || lastInput == 4 && direction == 3) 
                return lastInput;

            return direction;
        }
    }

    /// <summary>
    /// Class where the input methods exclusive to the game Minesweeper are managed
    /// </summary>
    public static class InDataMinesweeper
    {
        internal static int GetInput()
        {
            int action;
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    action = 1; // go up
                    break;
                case ConsoleKey.DownArrow:
                    action = 2; // go down
                    break;
                case ConsoleKey.RightArrow:
                    action = 3; // go right
                    break;
                case ConsoleKey.LeftArrow:
                    action = 4; // go left
                    break;
                case ConsoleKey.Spacebar:
                    action = 5; // reveal square
                    break;
                case ConsoleKey.Enter: 
                    action = 6; // put flag
                    break;
                case ConsoleKey.M:
                    action = 7; // go menu
                    break;
                default:
                    action = 0; // do nothing
                    break;
            }

            return action;
        }
    }
}