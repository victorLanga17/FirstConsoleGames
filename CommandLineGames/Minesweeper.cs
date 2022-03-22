/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class with the code of the game Minesweeper
 */

using System;

namespace CommandLineGames
{
    public class Minesweeper
    {
        internal void MenuMinesweeper()
        {
            SetConsoleParametersMinesweeper();

            bool end = false;
            do
            {
                OutDataMinesweeper.PrintTitleScreen();
                MinesweeperGame(ref end);
            } while (!end);
        }

        private void SetConsoleParametersMinesweeper()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(120, 40);
                Console.BufferWidth = 120;
                Console.BufferHeight = 40;
            }
        }

        private void MinesweeperGame(ref bool end)
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintMinesweeperTitle();
            Console.ReadKey();
        }
    }
}