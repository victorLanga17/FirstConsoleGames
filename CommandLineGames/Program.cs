﻿/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class where the program starts working
 */

using System;

namespace CommandLineGames
{
    public class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.Title = "Command Line Games by Victor Langa";
            ExternalSources.DisableConsoleResize.SetDisableResize();
            
            var program = new Program();
            program.Start();
        }

        private void Start()
        {
            bool end = false;

            do
            {
                PrintMenu();
                ChooseOption(ref end);
            } while (!end);
        }

        private void PrintMenu()
        {
            Console.WriteLine("Command Line Games");
            Console.WriteLine("By Victor Langa");
            Console.WriteLine("\n   [1] Snake");
        }

        private void ChooseOption(ref bool end)
        {
            char option = InData.GetChar("\n--- Introduce an option or press any other key to exit");
            switch (option)
            {
                case '1':
                    ExecuteSnake();
                    break;
                default:
                    end = true;
                    break;
            }
        }

        private void ExecuteSnake()
        {
            Console.Clear();
            var snakeGame = new Snake();
            snakeGame.MenuSnake();
            Console.Clear();
        }
    }
}