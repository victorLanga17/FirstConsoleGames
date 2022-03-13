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
            bool end = false;
            do
            {
                OutDataSnake.PrintTitleScreen();
                ChooseOption(ref end);
            } while (!end);
        }

        private void ChooseOption(ref bool end)
        {
            int option = Convert.ToInt32(InData.GetChar("PROVISIONAL 1(Start), 2 o 3")) - 48;
            switch (option)
            {
                case 1:
                    SnakeGame(ChooseLevelSize());
                    break;
                case 2:
                    break;
                default:
                    end = true;
                    break;
            }
        }

        private void SnakeGame(int levelSize)
        {
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
            
            SnakeStart(levelSize);
            
            do
            {
                if (objectivePosition[0] == snakePosition[0, 0] && objectivePosition[1] == snakePosition[0, 1])
                {
                    objectivePosition = GenerateObjective(snakePosition, levelSize);
                    counter++;
                    pointThisTurn = true;
                    snakePosition = ResizeSnake(snakePosition);
                }
                
                direction = InDataSnake.GetInput(direction);
                MoveSnake(snakePosition, direction, ref pointThisTurn);
                CheckIfEnd(counter, levelSize, ref endOfTheGame, snakePosition);
                
            } while (!endOfTheGame);
        }
        
        private int ChooseLevelSize()
        {
            int levelSize = (Convert.ToInt32(InData.GetChar("PROVISIONAL LEVELSIZE 1(10x10), (2)20x20 o (3)30x30"))-48) * 10;
            return levelSize;
        }

        private void SnakeStart(int levelSize)
        {
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
            {
                newSnakePosition[i, j] = snakePosition[i, j];
            }

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
        
        private void CheckIfEnd(int counter, int levelSize, ref bool endOfTheGame, int[,] snakePosition)
        {
            for (int i = 1; i < snakePosition.GetLength(0); i++)
                if (snakePosition[0, 0] == snakePosition[i, 0] && snakePosition[0, 1] == snakePosition[i, 1])
                    endOfTheGame = true;
            if (snakePosition[0, 0] == levelSize / -2 || snakePosition[0, 0] == levelSize / 2 ||
                snakePosition[0, 1] == levelSize / -2 || snakePosition[0, 1] == levelSize / 2)
                endOfTheGame = true;
            if (counter == (int) Math.Pow(levelSize - 1, 2)) endOfTheGame = true;
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