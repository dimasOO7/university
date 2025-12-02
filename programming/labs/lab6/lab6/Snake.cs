using System.Collections.Generic;
namespace lab6
{
    /// <summary>
    /// enum всех доступных вводов в змейке
    /// </summary>
    enum InputKeys
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        EXIT,
        NONE
    }
    /// <summary>
    /// Класс игры змейка
    /// </summary>
    class Snake
    {
        private char[,] word;

        public char[,] World
        {
            get
            {
                return word;
            }
        }

        private Queue<Vector2i> snake = new Queue<Vector2i>();

        private Vector2i snakeHead;

        private int result = 0;

        private int snakeSize = 3;

        /// <summary>
        /// кол-во свободных клеток
        /// </summary>
        public readonly int freeCells;

        private int worldSize = 20;

        private Random rnd;

        private Vector2i moveDirection = new Vector2i(0, -1);
        /// <summary>
        /// инициация игры
        /// </summary>
        public Snake(int seed, int worldsize, int walls)
        {
            rnd = new Random(seed);

            word = new char[worldSize, worldSize];
            freeCells = worldSize * worldSize - walls;
            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    word[i, j] = 'g';
                }
            }

            snakeHead = new Vector2i(rnd.Next(2, worldSize), rnd.Next(1, worldSize - snakeSize - 1));
            word[snakeHead.x, snakeHead.y] = 'h';

            for (int i = snakeSize - 1; i > 0; i--)
            {
                snake.Enqueue(new Vector2i(snakeHead.x, snakeHead.y + i));
                word[snakeHead.x, snakeHead.y + i] = 's';
            }
            snake.Enqueue(snakeHead);

            for (int i = 0; i < walls; i++)
            {
                Vector2i cords = new Vector2i(rnd.Next(0, worldSize), rnd.Next(0, worldSize));
                if (word[cords.x, cords.y] == 'g' && cords + new Vector2i(0, 1) != snakeHead)
                {
                    word[cords.x, cords.y] = 'w';
                }
                else
                {
                    i--;
                }
            }
            GenerateApple(false);
        }

        private void GenerateApple(bool display = true)
        {
            bool isGenerating = true;

            while (isGenerating)
            {
                Vector2i cords = new Vector2i(rnd.Next(0, worldSize), rnd.Next(0, worldSize));
                if (word[cords.x, cords.y] == 'g')
                {
                    if (display)
                    {
                        DisplayTile(cords, 'a');
                    }
                    else
                    {
                        word[cords.x, cords.y] = 'a';
                    }
                    isGenerating = false;
                }
            }
        }

        private void DisplayTile(Vector2i cord, char tile)
        {
            word[cord.x, cord.y] = tile;
        }

        /// <summary>
        /// обновить направление движения змейки
        /// </summary>
        /// <param name="key">нажатая клавиша</param>
        public void SetMoveDirection(InputKeys key)
        {
            Vector2i newDirection = moveDirection;

            switch (key)
            {
                case InputKeys.UP:
                    newDirection = new Vector2i(0, -1);
                    break;
                case InputKeys.DOWN:
                    newDirection = new Vector2i(0, 1);
                    break;
                case InputKeys.LEFT:
                    newDirection = new Vector2i(-1, 0);
                    break;
                case InputKeys.RIGHT:
                    newDirection = new Vector2i(1, 0);
                    break;
                default:
                    return;
            }

            
            if (newDirection.x != -moveDirection.x || newDirection.y != -moveDirection.y)
            {
                moveDirection = newDirection;
            }
        }

        /// <summary>
        /// выполнить игровой тик
        /// </summary>
        /// <returns> результат или -1 при поражении</returns>
        public int GameTick()
        {

            DisplayTile(snakeHead, 's');

            snakeHead = (snakeHead + moveDirection + worldSize) % worldSize;

            snake.Enqueue(snakeHead);

            if (word[snakeHead.x, snakeHead.y] == 'a')
            {
                DisplayTile(snakeHead, 'h');
                result++;
                if (snakeSize + result < freeCells)
                {
                    GenerateApple();
                }
                return result;
            }
            else if (word[snakeHead.x, snakeHead.y] == 'w' || word[snakeHead.x, snakeHead.y] == 's')
            {
                return -1;
            }
            Vector2i lastSegment = snake.Dequeue();
            DisplayTile(snakeHead, 'h');
            DisplayTile(lastSegment, 'g');
            return 0;
        }

    }
}