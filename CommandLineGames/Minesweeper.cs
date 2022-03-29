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
        private int _minesNextGame = 100;
        private int[,] _board = new int[20, 30];
        private int[] _cursorPosition = {0, 0};
        private int _revealedBoxes;
        
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
            OutDataMinesweeper.PrintHowToEnterMenu();

            bool end = false;
            
            do
            {
                _cursorPosition = new [] {0, 0};
                _revealedBoxes = 0;
                OutDataMinesweeper.PrintBoard();
                GenerateNewMinesPositions();
                FillBoardWithCorrespondentValues();
                bool isVictory = MinesweeperGameLoop(ref end);
                if (!end) EndScreen(isVictory);
                OutDataMinesweeper.ClearNextGameDifficulty();
            } while (!end);
        }

        private void GenerateNewMinesPositions()
        {
            int minesPlaced = 0;
            var random = new Random();

            for (int i = 0; i < _board.GetLength(0) && minesPlaced < _minesNextGame; i++)
                for (int j = 0; j < _board.GetLength(1) && minesPlaced < _minesNextGame; j++)
                    _board[i, j] = 0;
            
            do
            {
                for (int i = 0; i < _board.GetLength(0) && minesPlaced < _minesNextGame; i++)
                {
                    for (int j = 0; j < _board.GetLength(1) && minesPlaced < _minesNextGame; j++)
                    {
                        if (random.Next(0, 25) != 1 || (_board[i, j] == 10)) continue;
                        minesPlaced++;
                        _board[i, j] = 10;
                    }
                }
            } while (minesPlaced < _minesNextGame);
        }

        private void FillBoardWithCorrespondentValues()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] == 10) continue;
                    
                    int surroundingMines = 0;
                    surroundingMines += CheckTopValues(i, j);
                    surroundingMines += CheckBottomValues(i, j);
                    surroundingMines += CheckLeftAndRight(i, j);

                    if (surroundingMines == 0) surroundingMines = 9;
                    _board[i, j] = surroundingMines;
                }
            }
        }
        
        private bool MinesweeperGameLoop(ref bool end)
        {
            Console.CursorVisible = true;
            int minesCurrentGame = _minesNextGame;
            bool finishedGame;
            bool isVictory = false;
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 4 + 2);
            
            do
            {
                int action = InDataMinesweeper.GetInput();
                DoAction(action, ref end);
                finishedGame = CheckIfEnd(ref isVictory, minesCurrentGame);
            } while (!end && !finishedGame);

            return isVictory;
        }

        private void EndScreen(bool isVictory)
        {
            Console.CursorVisible = false;

            if (!isVictory) OutDataMinesweeper.PrintDefeat();
            else OutDataMinesweeper.PrintWin();

            char input;
            do
            {
                Console.SetCursorPosition(Console.WindowWidth / 4 + 15, Console.WindowHeight / 4 + 26);
                input = InData.GetChar("Press [0] to start a new game");
            } while (input != '0');
            
            OutDataMinesweeper.ClearWinOrDefeat();
            Console.CursorVisible = true;
        }

        private int CheckTopValues(int i, int j)
        {
            int surroundingMines = 0;
            
            if (i != 0)
            {
                if (j != 0)
                    if (_board[i - 1, j - 1] == 10) surroundingMines++;
                        
                if (_board[i - 1, j] == 10) surroundingMines++;
                        
                if (j != _board.GetLength(1) - 1)
                    if (_board[i - 1, j + 1] == 10) surroundingMines++;
            }

            return surroundingMines;
        }

        private int CheckBottomValues(int i, int j)
        {
            int surroundingMines = 0;
            
            if (i != _board.GetLength(0) - 1)
            {
                if (j != 0)
                    if (_board[i + 1, j - 1] == 10) surroundingMines++;
                        
                if (_board[i + 1, j] == 10) surroundingMines++;
                        
                if (j != _board.GetLength(1) - 1)
                    if (_board[i + 1, j + 1] == 10) surroundingMines++;
            }

            return surroundingMines;
        }

        private int CheckLeftAndRight(int i, int j)
        {
            int surroundingMines = 0;
            
            if (j != 0)
                if (_board[i, j - 1] == 10) surroundingMines++;
                    
            if (j != _board.GetLength(1) - 1)
                if (_board[i, j + 1] == 10) surroundingMines++;
            
            return surroundingMines;
        }

        private void DoAction(int action, ref bool end)
        {
            switch (action)
            {
                case 1:
                    MoveCursorUp();
                    break;
                case 2:
                    MoveCursorDown();
                    break;
                case 3:
                    MoveCursorRight();
                    break;
                case 4:
                    MoveCursorLeft();
                    break;
                case 5:
                    RevealBoxValue();
                    break;
                case 6:
                    SetOrUnsetFlag();
                    break;
                case 7:
                    GoMenu(ref end);
                    break;
            }
        }

        private bool CheckIfEnd(ref bool isVictory, int minesCurrentGame)
        {
            if (Console.ForegroundColor == ConsoleColor.Red)
            {
                Console.ResetColor();
                return true;
            }
            if (_revealedBoxes == _board.GetLength(0) * _board.GetLength(1) - minesCurrentGame)
            {
                isVictory = true;
                return true;
            }
            return false;
        }

        private void GoMenu(ref bool end)
        {
            int[] position = {Console.CursorLeft, Console.CursorTop};
            Console.CursorVisible = false;
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
            
            Console.SetCursorPosition(position[0], position[1]);
            Console.CursorVisible = true;
        }

        private void MoveCursorUp()
        {
            if (_cursorPosition[0] != 0)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                _cursorPosition[0]--;
            }
        }
        
        private void MoveCursorDown()
        {
            if (_cursorPosition[0] != _board.GetLength(0) - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                _cursorPosition[0]++;
            }
        }
        
        private void MoveCursorRight()
        {
            if (_cursorPosition[1] != _board.GetLength(1) - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop );
                _cursorPosition[1]++;
            }
        }
        
        private void MoveCursorLeft()
        {
            if (_cursorPosition[1] != 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                _cursorPosition[1]--;
            }
        }

        private void RevealBoxValue()
        {
            bool revealSurroundBoxes = false;
            if (_board[_cursorPosition[0], _cursorPosition[1]] == 0) return;
            if (_board[_cursorPosition[0], _cursorPosition[1]] < 0)
                _board[_cursorPosition[0], _cursorPosition[1]] *= -1;

            string value;
            if (_board[_cursorPosition[0], _cursorPosition[1]] == 9)
            {
                value = "·";
                revealSurroundBoxes = true;
            }
            else if (_board[_cursorPosition[0], _cursorPosition[1]] == 10) value = "∅";
            else value = Convert.ToString(_board[_cursorPosition[0], _cursorPosition[1]]);
            
            OutDataMinesweeper.PrintBoxValue(value);
            _revealedBoxes++;
            _board[_cursorPosition[0], _cursorPosition[1]] = 0;
            if (revealSurroundBoxes) RevealSurroundingBoxesIfValue9();
        }
        
        private void SetOrUnsetFlag()
        {
            switch (_board[_cursorPosition[0], _cursorPosition[1]])
            {
                case > 0:
                    OutDataMinesweeper.PrintPutFlag();
                    _board[_cursorPosition[0], _cursorPosition[1]] *= -1;
                    break;
                case < 0:
                    OutDataMinesweeper.PrintQuitFlag();
                    _board[_cursorPosition[0], _cursorPosition[1]] *= -1;
                    break;
            }
        }
        
        private void ChangeDifficulty()
        {
            OutDataMinesweeper.PrintDifficultyOptions();
            
            int newDifficulty = InData.GetMenuOption(3, Console.WindowWidth / 4 - 5, 26);
            switch (newDifficulty)
            {
                case 1:
                    _minesNextGame = 50;
                    break;
                case 2:
                    _minesNextGame = 100;
                    break;
                default:
                    _minesNextGame = 150;
                    break;
            }
            
            OutDataMinesweeper.PrintNextGameDifficulty();
            OutDataMinesweeper.ClearDifficultyOptions();
        }

        private void RevealSurroundingBoxesIfValue9()
        {
            int[] initialPosition = {Console.CursorLeft, Console.CursorTop};
            int[] initialCursorPosition = {_cursorPosition[0], _cursorPosition[1]};

            RevealTop(initialPosition, initialCursorPosition);
            RevealBottom(initialPosition, initialCursorPosition);
            RevealLeftAndRight(initialPosition, initialCursorPosition);

            Console.SetCursorPosition(initialPosition[0], initialPosition[1]);
            _cursorPosition = new[] {initialCursorPosition[0], initialCursorPosition[1]};
        }

        private void RevealTop(int[] initialPosition, int[] initialCursorPosition)
        {
            if (initialCursorPosition[0] > 0)
            {
                if (initialCursorPosition[1] > 0)
                {
                    Console.SetCursorPosition(initialPosition[0] - 2, initialPosition[1] - 1);
                    _cursorPosition = new[] {initialCursorPosition[0] - 1, initialCursorPosition[1] - 1};
                    RevealBoxValue();
                }
                
                Console.SetCursorPosition(initialPosition[0], initialPosition[1] - 1);
                _cursorPosition = new[] {initialCursorPosition[0] - 1, initialCursorPosition[1]};
                RevealBoxValue();

                if (initialCursorPosition[1] < _board.GetLength(1) - 1)
                {
                    Console.SetCursorPosition(initialPosition[0] + 2 , initialPosition[1] - 1);
                    _cursorPosition = new[] {initialCursorPosition[0] - 1, initialCursorPosition[1] + 1};
                    RevealBoxValue();
                }
            }
        }

        private void RevealBottom(int[] initialPosition, int[] initialCursorPosition)
        {
            if (initialCursorPosition[0] < _board.GetLength(0) - 1)
            {
                if (initialCursorPosition[1] > 0)
                {
                    Console.SetCursorPosition(initialPosition[0] - 2, initialPosition[1] + 1);
                    _cursorPosition = new[] {initialCursorPosition[0] + 1, initialCursorPosition[1] - 1};
                    RevealBoxValue();
                }
                
                Console.SetCursorPosition(initialPosition[0], initialPosition[1] + 1);
                _cursorPosition = new[] {initialCursorPosition[0] + 1, initialCursorPosition[1]};
                RevealBoxValue();

                if (initialCursorPosition[1] < _board.GetLength(1) - 1)
                {
                    Console.SetCursorPosition(initialPosition[0] + 2 , initialPosition[1] + 1);
                    _cursorPosition = new[] {initialCursorPosition[0] + 1, initialCursorPosition[1] + 1};
                    RevealBoxValue();
                }
            }
        }

        private void RevealLeftAndRight(int[] initialPosition, int[] initialCursorPosition)
        {
            if (initialCursorPosition[1] > 0)
            {
                Console.SetCursorPosition(initialPosition[0] - 2, initialPosition[1]);
                _cursorPosition = new[] {initialCursorPosition[0], initialCursorPosition[1] - 1};
                RevealBoxValue();
            }

            if (initialCursorPosition[1] < _board.GetLength(1) - 1)
            {
                Console.SetCursorPosition(initialPosition[0] + 2, initialPosition[1]);
                _cursorPosition = new[] {initialCursorPosition[0], initialCursorPosition[1] + 1};
                RevealBoxValue();
            }
        }
    }
}