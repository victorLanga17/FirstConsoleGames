/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where are the input methods are managed
 */

using System;
using System.Threading;

namespace CommandLineGames
{
    public static class InData
    {
        public static char GetChar(string message)
        {
            Console.WriteLine(message);
            return Console.ReadKey().KeyChar;
        }
    }

    public static class InDataSnake
    {
        internal static int GetMenuOption()
        {
            int option = 1;
            bool end = false;

            while (!end)
            {
                OutDataSnake.PrintMenuCursor(option);
                var input = Console.ReadKey();
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
        
        internal static int GetInput(int lastInput)
        { 
            Thread.Sleep(1000);
            
            while (!Console.KeyAvailable) return lastInput;

            int direction = lastInput;
            ConsoleKeyInfo newDirection = Console.ReadKey();
            
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

            while (Console.KeyAvailable) Console.ReadKey(false);
            
            if (lastInput == 1 && direction == 2 || lastInput == 2 && direction == 1 ||
                lastInput == 3 && direction == 4 || lastInput == 4 && direction == 3) 
                return lastInput;

            return direction;
        }
    }
}