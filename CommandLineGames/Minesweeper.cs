/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class with the code of the game Minesweeper
 */

using System;

namespace CommandLineGames
{
    /// <summary>
    /// Class with the methods of the game Minesweeper
    /// </summary>
    public class Minesweeper
    {
        /// <summary>
        /// Integral with the number of mines that will be placed in the next game
        /// </summary>
        private int _minesNextGame = 100;
        
        /// <summary>
        /// Integral matrix with the dimensions of the board
        /// </summary>
        private int[,] _board = new int[20, 30];
        
        /// <summary>
        /// Integral matrix with the current cursor position
        /// </summary>
        private int[] _cursorPosition = {0, 0};
        
        /// <summary>
        /// Integral with the number of boxes revealed
        /// </summary>
        private int _revealedBoxes;
        
        /// <summary>
        /// Method where Minesweeper starts
        /// </summary>
        internal void MinesweeperMain()
        {
            SetConsoleParametersMinesweeper();
            OutDataMinesweeper.PrintTitleScreen();
            MinesweeperInitialize();
        }

        /// <summary>
        /// Method that sets the console parameters for Minesweeper
        /// </summary>
        private void SetConsoleParametersMinesweeper()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(120, 40);
                Console.BufferWidth = 120;
                Console.BufferHeight = 40;
            }
        }

        /// <summary>
        /// Method where the game initializes and repeats when it ends
        /// </summary>
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

        /// <summary>
        /// Method that generates the mines in the board
        /// </summary>
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

        /// <summary>
        /// Method that fills the non-mine boxes with the values that correspond to each game
        /// </summary>
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
        
        /// <summary>
        /// Method with the game loop
        /// </summary>
        /// <param name="end">Boolean that indicates if the game has to stop its execution</param>
        /// <returns>Boolean that indicates if a game ends in a win or a defeat</returns>
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

        /// <summary>
        /// Method with the end screen
        /// </summary>
        /// <param name="isVictory">Boolean that indicates if a game ends in a win or a defeat</param>
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

        /// <summary>
        /// Method that checks if the three top boxes of the current position have mines
        /// </summary>
        /// <param name="i">Row position</param>
        /// <param name="j">Column position</param>
        /// <returns>Integral with the number of boxes with mines</returns>
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

        /// <summary>
        /// Method that checks if the three bottom boxes of the current position have mines
        /// </summary>
        /// <param name="i">Row position</param>
        /// <param name="j">Column position</param>
        /// <returns>Integral with the number of boxes with mines</returns>
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

        /// <summary>
        /// Method that checks if the left and right boxes of the current position have mines
        /// </summary>
        /// <param name="i">Row position</param>
        /// <param name="j">Column position</param>
        /// <returns>Integral with the number of boxes with mines</returns>
        private int CheckLeftAndRight(int i, int j)
        {
            int surroundingMines = 0;
            
            if (j != 0)
                if (_board[i, j - 1] == 10) surroundingMines++;
                    
            if (j != _board.GetLength(1) - 1)
                if (_board[i, j + 1] == 10) surroundingMines++;
            
            return surroundingMines;
        }

        /// <summary>
        /// Method where the input translates in its corresponding action
        /// </summary>
        /// <param name="action">Integral with the user's input</param>
        /// <param name="end">Boolean that indicates if the game has to stop</param>
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

        /// <summary>
        /// Method that tells if the game must end
        /// </summary>
        /// <param name="isVictory">Boolean that indicates if a game ends in a win or a defeat</param>
        /// <param name="minesCurrentGame">Integral with the number of mines in the current game</param>
        /// <returns>Boolean that indicates if the game has to end</returns>
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

        /// <summary>
        /// Method where the menu actions are managed
        /// </summary>
        /// <param name="end">Boolean that indicates if the game has to end</param>
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

        /// <summary>
        /// Method that moves the cursor up during the game
        /// </summary>
        private void MoveCursorUp()
        {
            if (_cursorPosition[0] != 0)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                _cursorPosition[0]--;
            }
        }
        
        /// <summary>
        /// Method that moves the cursor down during the game
        /// </summary>
        private void MoveCursorDown()
        {
            if (_cursorPosition[0] != _board.GetLength(0) - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                _cursorPosition[0]++;
            }
        }
        
        /// <summary>
        /// Method that moves the cursor right during the game
        /// </summary>
        private void MoveCursorRight()
        {
            if (_cursorPosition[1] != _board.GetLength(1) - 1)
            {
                Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop );
                _cursorPosition[1]++;
            }
        }
        
        /// <summary>
        /// Method that moves the cursor left during the game
        /// </summary>
        private void MoveCursorLeft()
        {
            if (_cursorPosition[1] != 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                _cursorPosition[1]--;
            }
        }

        /// <summary>
        /// Method that reveals the value of the box where the cursor is
        /// </summary>
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
        
        /// <summary>
        /// Method that sets or unsets a flag
        /// </summary>
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
        
        /// <summary>
        /// Method where the difficulty setting are managed
        /// </summary>
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

        /// <summary>
        /// Method that reveals all the locations around a box
        /// </summary>
        /// <remarks>
        /// This method works with RevealBoxValue() in a recursive way to reveal all the positions when multiple value 9(0) boxes are revealed
        /// </remarks>>
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

        /// <summary>
        /// Method that reveals the three top boxes of the current position
        /// </summary>
        /// <param name="initialPosition">Int array with the cursor's original position in the board</param>
        /// <param name="initialCursorPosition">Int array with the cursor's original position in the console</param>
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

        /// <summary>
        /// Method that reveals the three bottom boxes of the current position
        /// </summary>
        /// <param name="initialPosition">Int array with the cursor's original position in the board</param>
        /// <param name="initialCursorPosition">Int array with the cursor's original position in the console</param>
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

        /// <summary>
        /// Method that reveals the left and right boxes of the current position
        /// </summary>
        /// <param name="initialPosition">Int array with the cursor's original position in the board</param>
        /// <param name="initialCursorPosition">Int array with the cursor's original position in the console</param>
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