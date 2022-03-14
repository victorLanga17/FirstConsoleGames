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
            return Console.ReadKey().KeyChar;
        }
    }

    /// <summary>
    /// Class where the input methods exclusive to the game Snake are managed
    /// </summary>
    public static class InDataSnake
    {
        /// <summary>
        /// Method that determines the option taken in the menu
        /// </summary>
        /// <returns>Int with the option taken</returns>
        internal static int GetMenuOption()
        {
            int option = 1;
            bool end = false;

            while (!end)
            {
                OutDataSnake.PrintMenuCursor(option);
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.UpArrow)
                {
                    if (option == 1) option = 3;
                    else option--;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (option == 3) option = 1;
                    else option++;
                }
                else if (input.Key == ConsoleKey.Enter) end = true;
            }

            return option;
        }
        
        /// <summary>
        /// Method that determines the next direction the snake will be facing during the game
        /// </summary>
        /// <param name="lastInput">Last input registered before the execution of the method</param>
        /// <returns>Int that represents the direction of the snake</returns>
        internal static int GetInput(int lastInput)
        { 
            Thread.Sleep(600);
            
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
}