/*
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
            Console.WriteLine("");
        }

        private void ChooseOption(ref bool end)
        {
            string option = InData.GetString("--- Introduce an option or press any other key to exit");
            switch (option)
            {
                case "1":
                    break;
                default:
                    end = true;
                    break;
            }
        }

        
        
        
    }
}