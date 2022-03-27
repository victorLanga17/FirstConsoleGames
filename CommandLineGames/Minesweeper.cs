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
        private int mines = 100;
        
        internal void MinesweeperMain()
        {
            SetConsoleParametersMinesweeper();
            OutDataMinesweeper.PrintTitleScreen();
            MinesweeperInitialize();
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

        private void MinesweeperInitialize()
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintMinesweeperTitle();
            OutDataMinesweeper.PrintInstructions();
            OutDataMinesweeper.PrintBoard();
            OutDataMinesweeper.PrintHowToEnterMenu();

            MinesweeperGameLoop();
        }

        private void MinesweeperGameLoop()
        {
            bool end = false;
            bool isVictory = false;
            int[] board = {20, 25};
            do
            {
                int action = InDataMinesweeper.GetInput();
                DoAction(action, ref end);
                // CheckIfEnd
            } while (!end);
        }

        private void DoAction(int action, ref bool end)
        {
            if (action == 7) GoMenu(ref end);
            else /*to do inputs here*/;
        }

        private void GoMenu(ref bool end)
        {
            bool endMenu = false;

            do
            {
                OutDataMinesweeper.PrintMenu();
                int menuAction = InData.GetMenuOption(3, Console.WindowWidth / 4 - 25, 24);

                if (menuAction == 3) end = true;
                else if (menuAction == 1)
                {
                    endMenu = true;
                    OutDataMinesweeper.ClearMenu();
                }
                else ChangeDifficulty() ; 
            } while (!end && !endMenu);
        }

        private void ChangeDifficulty()
        {
            OutDataMinesweeper.PrintDifficultyOptions();
            
            int newDifficulty = InData.GetMenuOption(3, Console.WindowWidth / 4 - 5, 26);
            switch (newDifficulty)
            {
                case 1:
                    mines = 50;
                    break;
                case 2:
                    mines = 100;
                    break;
                default:
                    mines = 150;
                    break;
            }
            
            OutDataMinesweeper.PrintNextGameDifficulty();
            OutDataMinesweeper.ClearDifficultyOptions();
        }
    }
}