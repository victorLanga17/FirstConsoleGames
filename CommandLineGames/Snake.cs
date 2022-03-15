/*
 * Author: Victor Langa de la Fuente
 * Date: 13/03/2022
 * Description: Class with the code of the game Snake
 */

using System;

namespace CommandLineGames
{
    /// <summary>
    /// Class with the methods of the game Snake
    /// </summary>
    internal class Snake
    {
        /// <summary>
        /// Method where the Snake program loop starts
        /// </summary>
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

        /// <summary>
        /// Method to adjust the console parameters to the Snake game
        /// </summary>
        private void SetConsoleParametersSnake()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(100, 50);
                Console.BufferWidth = 100;
                Console.BufferHeight = 50;
            }
        }

        /// <summary>
        /// Method that goes to an option chosen from the main menu
        /// </summary>
        /// <param name="end">Boolean that determines if the program must end</param>
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
        
        /// <summary>
        /// Method where the level of difficulty is chosen
        /// </summary>
        /// <returns>Int with the level size</returns>
        private int ChooseLevelSize()
        {
            OutDataSnake.PrintChooseDifficulty();
            int levelSize = InDataSnake.GetMenuOption() * 10;
            return levelSize;
        }
        
        /// <summary>
        /// Method where the game Snake executes
        /// </summary>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
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
                
                direction = InDataSnake.GetInput(direction, levelSize);
                MoveSnake(snakePosition, direction, ref pointThisTurn);
                isVictory = CheckIfEnd(counter, levelSize, ref endOfTheGame, snakePosition);
                
            } while (!endOfTheGame);

            OutDataSnake.EndScreen(isVictory, counter);
        }

        /// <summary>
        /// Method where the output initialization is done
        /// </summary>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
        private void StartSnake(int levelSize)
        {
            OutDataSnake.PrintScore(0);
            OutDataSnake.PrintLevel(levelSize);
            OutDataSnake.PrintInitialPosition(levelSize);
        }
        
        /// <summary>
        /// Method where a new objective is generate when the current is taken or doesn't exist
        /// </summary>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
        /// <returns>Integer array with the new position</returns>
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
        
        /// <summary>
        /// Method that resizes the snake (adding one more length)
        /// </summary>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <returns>Int matrix with the new length and position of the snake</returns>
        private int[,] ResizeSnake(int[,] snakePosition)
        {
            int[,] newSnakePosition = new int[snakePosition.GetLength(0) + 1, 2];
            
            for (int i = 0; i < snakePosition.GetLength(0); i++)
                for (int j = 0; j < snakePosition.GetLength(1); j++)
                    newSnakePosition[i, j] = snakePosition[i, j];
            
            return newSnakePosition;
        }

        /// <summary>
        /// Method where the new positions occupied by the snake are determined when a turn ends
        /// </summary>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <param name="direction">Int that represents the direction the snake is facing</param>
        /// <param name="pointThisTurn">Boolean that shows if a point was taken during the turn analyzed</param>
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
        
        /// <summary>
        /// Method that checks every turn if the game shall end
        /// </summary>
        /// <param name="counter">Int with the score</param>
        /// <param name="levelSize">Int with the level size chosen (relative to the difficulty option)</param>
        /// <param name="endOfTheGame">Bool that determines if the game shall end</param>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <returns>Bool that determines if the game was won or lost</returns>
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

        /// <summary>
        /// Method that checks if the position isn't occupied by the snake to generate a new objective 
        /// </summary>
        /// <param name="objectivePosition">Integer array with the new position</param>
        /// <param name="snakePosition">Integral matrix with the current snake position</param>
        /// <returns>Bool that determines if the position is occupied or not</returns>
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