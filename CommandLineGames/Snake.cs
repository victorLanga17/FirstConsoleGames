/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class with the code of the game Snake
 */

using System;

namespace CommandLineGames
{
    internal class Snake
    {
        internal void MenuSnake()
        {
            SetConsoleParametersSnake();
            
            bool end = false;
            do
            {
                OutDataSnake.PrintTitleScreen();
                ChooseOption(ref end);
            } while (!end);
        }

        private void SetConsoleParametersSnake()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(100, 50);
                Console.BufferWidth = 100;
                Console.BufferHeight = 50;
            }
        }

        private void ChooseOption(ref bool end)
        {
            int option = InDataSnake.GetMenuOption();
            switch (option)
            {
                case 1:
                    SnakeGame(ChooseLevelSize());
                    break;
                case 2:
                    OutDataSnake.PrintInstructions();
                    break;
                default:
                    end = true;
                    break;
            }
        }

        private void SnakeGame(int levelSize)
        {
            Console.Clear();
            ExternalSources.AsciiElements.PrintSnakeTitle();
            
            int[,] snakePosition =
            {
                {0 + 2 * levelSize / 10, 0},
                {1 + 2 * levelSize / 10, 0},
                {2 + 2 * levelSize / 10, 0}
            };
            int[] objectivePosition = GenerateObjective(snakePosition, levelSize);
            int counter = 0;
            bool pointThisTurn = false;
            int direction = 2;
            bool endOfTheGame = false;
            bool isVictory;
            
            StartSnake(levelSize);
            
            do
            {
                if (objectivePosition[0] == snakePosition[0, 0] && objectivePosition[1] == snakePosition[0, 1])
                {
                    objectivePosition = GenerateObjective(snakePosition, levelSize);
                    counter++;
                    OutDataSnake.PrintScore(counter);
                    pointThisTurn = true;
                    snakePosition = ResizeSnake(snakePosition);
                }
                
                direction = InDataSnake.GetInput(direction);
                MoveSnake(snakePosition, direction, ref pointThisTurn);
                isVictory = CheckIfEnd(counter, levelSize, ref endOfTheGame, snakePosition);
                
            } while (!endOfTheGame);

            OutDataSnake.EndScreen(isVictory, counter);
        }
        
        private int ChooseLevelSize()
        {
            OutDataSnake.PrintChooseDifficulty();
            int levelSize = InDataSnake.GetMenuOption() * 10;
            return levelSize;
        }

        private void StartSnake(int levelSize)
        {
            OutDataSnake.PrintScore(0);
            OutDataSnake.PrintLevel(levelSize);
            OutDataSnake.PrintInitialPosition(levelSize);
        }
        
        private int[] GenerateObjective(int[,] snakePosition, int levelSize)
        {
            var randomPosition = new Random();
            int[] objectivePosition;
            do
            {
                objectivePosition = new [] {randomPosition.Next(levelSize/-2 + 1, levelSize/2),
                    randomPosition.Next(levelSize/-2 + 1, levelSize/2)};
            } while (!CheckIfPositionIsFree(objectivePosition, snakePosition));

            OutDataSnake.PrintNewObjective(objectivePosition);

            return objectivePosition;
        }
        
        private int[,] ResizeSnake(int[,] snakePosition)
        {
            int[,] newSnakePosition = new int[snakePosition.GetLength(0) + 1, 2];
            
            for (int i = 0; i < snakePosition.GetLength(0); i++)
                for (int j = 0; j < snakePosition.GetLength(1); j++)
                    newSnakePosition[i, j] = snakePosition[i, j];
            
            return newSnakePosition;
        }

        private void MoveSnake(int[,] snakePosition, int direction, ref bool pointThisTurn)
        {
            int[] posToDelete = {snakePosition[snakePosition.GetLength(0) - 1, 0], 
                snakePosition[snakePosition.GetLength(0) - 1, 1]};

            for (int i = snakePosition.GetLength(0) - 1; i > 0; i--)
            {
                snakePosition[i, 0] = snakePosition[i - 1, 0];
                snakePosition[i, 1] = snakePosition[i - 1, 1];
            }

            // 1 = right, 2 = left, 3 = up, 4 = down
            if (direction == 1) snakePosition[0, 0]++;
            else if (direction == 2) snakePosition[0, 0]--;
            else if (direction == 3) snakePosition[0, 1]--;
            else snakePosition[0, 1]++;
            
            OutDataSnake.PrintNewTurn(ref pointThisTurn, snakePosition, posToDelete);
        }
        
        private bool CheckIfEnd(int counter, int levelSize, ref bool endOfTheGame, int[,] snakePosition)
        {
            if (counter == (int) Math.Pow(levelSize - 1, 2) - 3)
            {
                endOfTheGame = true;
                return true;
            }
            
            for (int i = 1; i < snakePosition.GetLength(0); i++)
                if (snakePosition[0, 0] == snakePosition[i, 0] && snakePosition[0, 1] == snakePosition[i, 1])
                    endOfTheGame = true;
            
            if (snakePosition[0, 0] == levelSize / -2 || snakePosition[0, 0] == levelSize / 2 ||
                snakePosition[0, 1] == levelSize / -2 || snakePosition[0, 1] == levelSize / 2)
                endOfTheGame = true;
            
            return false;
        }

        private bool CheckIfPositionIsFree(int[] objectivePosition, int[,] snakePosition)
        {
            bool isPositionFree = true;

            for (int i = 0; i < snakePosition.GetLength(0) && isPositionFree; i++)
                if (objectivePosition[0] == snakePosition[i, 0] && objectivePosition[1] == snakePosition[i, 1])
                    isPositionFree = false;

            return isPositionFree;
        }
    }
}