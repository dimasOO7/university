using System.Collections.Generic;
namespace lab
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

        private static (int size, int walls, int delay)[] difficulties = { (10, 10, 500), (20, 40, 400), (30, 75, 300) };

        private char[,] word;

        private Queue<Vector2i> snake = new Queue<Vector2i>();

        private Vector2i snakeHead;

        private Vector2i startPosition;

        private int result = 0;

        private int snakeSize = 3;

        private int freeCells;

        private int worldSize = 20;

        private int frameDelay = 500;

        private int seed;

        private Random rnd;

        private Vector2i moveDirection = new Vector2i(0, -1);
        /// <summary>
        /// инициация игры
        /// </summary>
        public Snake()
        {
            int menuResult = Menu.MenuSelection(["лёгкая", "средняя", "высокая", "собственная"], "========= Выбор Сложности =========");
            int walls;

            switch (menuResult)
            {
                case 3:
                    worldSize = Math.Clamp(Inputs.InputInt("Введите размер поля (от 5 до 30): "), 5, 30);
                    walls = Math.Clamp(Inputs.InputInt($"Введите количество препятствий(не более {(int)Math.Pow(worldSize, 1.4)}): "), 0, (int)Math.Pow(worldSize, 1.4));
                    frameDelay = Math.Max(Inputs.InputInt("Введите задержку между кадрами (в мс): "), 1);
                    break;

                default:
                    worldSize = difficulties[menuResult].size;
                    walls = difficulties[menuResult].walls;
                    frameDelay = difficulties[menuResult].delay;
                    break;
            }

            seed = Inputs.InputInt("Введите сид (введите 0 для случайного): ");

            if (seed == 0)
            {
                rnd = new Random();
                seed = rnd.Next();
            }
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
            startPosition = snakeHead;
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

        private void RestartGame()
        {
            for (int i = 0; i < worldSize; i++)
            {
                for (int j = 0; j < worldSize; j++)
                {
                    if (word[i, j] == 'h' || word[i, j] == 's' || word[i, j] == 'a')
                    {
                        word[i, j] = 'g';
                    }
                }
            }
            result = 0;
            snakeHead = startPosition;
            snake.Clear();
            word[snakeHead.x, snakeHead.y] = 'h';

            for (int i = snakeSize - 1; i > 0; i--)
            {
                snake.Enqueue(new Vector2i(snakeHead.x, snakeHead.y + i));
                word[snakeHead.x, snakeHead.y + i] = 's';
            }
            snake.Enqueue(snakeHead);
            GenerateApple(false);
            moveDirection = new Vector2i(0, -1);
            DisplayWorld();
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

        private void DisplayWorld()
        {
            //Screen.Clear(Global.startCursorPosition.Top);
            Console.Clear();
            for (int y = 0; y < worldSize; y++)
            {
                for (int x = 0; x < worldSize; x++)
                {
                    DisplayTile(x, y);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine($"собрано яблок: {result}");
        }
        
        private void DisplayTile(Vector2i cord, char tile)
        {
            word[cord.x, cord.y] = tile;
            DisplayTile(cord);
        }

        private void DisplayTile(Vector2i cord)
        {
            DisplayTile(cord.x, cord.y);
        }

        private void DisplayTile(int x, int y)
        {


            Console.SetCursorPosition(x * 2, y);
            switch (word[x, y])
            {
                case 'g':
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                    break;

                case 'w':
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("  ");
                    break;

                case 'h':
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("󰈈󰈈");
                    break;

                case 's':
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Write("  ");
                    break;

                case 'a':
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ");
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    break;
            }

            Console.ResetColor();
        }
        
        private void DisplayResult()
        {
            Console.SetCursorPosition(0, worldSize);
            Console.WriteLine($"собрано яблок: {result}");
        }

        private int GameIteration()
        {
            switch (Input())
            {
                case InputKeys.UP:
                    if (moveDirection.y != 1)
                    {
                        moveDirection = new Vector2i(0, -1);
                    }
                    break;
                case InputKeys.DOWN:
                    if (moveDirection.y != -1)
                    {
                        moveDirection = new Vector2i(0, 1);
                    }
                    break;
                case InputKeys.RIGHT:
                    if (moveDirection.x != -1)
                    {
                        moveDirection = new Vector2i(1, 0);
                    }
                    break;
                case InputKeys.LEFT:
                    if (moveDirection.x != 1)
                    {
                        moveDirection = new Vector2i(-1, 0);
                    }
                    break;
                case InputKeys.EXIT:
                    return -1;
            }

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
                return 1;
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
        /// <summary>
        /// Начать игру
        /// !!!Внимание очищает экран
        /// </summary>
        public void RunGame()
        {
            DisplayWorld();
            System.Threading.Thread.Sleep(1000);
            Console.CursorVisible = false;
            bool isRunning = true;
            while (isRunning)
            {
                int iterationResult = GameIteration();
                if (iterationResult < 0)
                {
                    isRunning = Menu.MenuSelection(["нет", "да"], $"гг, результат: {result} \nсид был: {seed}\nПерезапустить игру на той же карте?") == 1;
                    if (isRunning)
                    {
                        RestartGame();
                    }
                }
                else
                {
                    if (snakeSize + result == freeCells)
                    {
                        isRunning = Menu.MenuSelection(["нет", "да"], $"ГОООООООЛ, результат: {result} \nсид был: {seed}\nПерезапустить игру на той же карте?") == 1;
                        if (isRunning)
                        {
                            RestartGame();
                        }
                    }
                }
                if (isRunning)
                {
                    DisplayResult();
                    System.Threading.Thread.Sleep(frameDelay);
                }
            }
            Console.CursorVisible = true;
        }

        static InputKeys Input()
        {
            InputKeys result = InputKeys.NONE;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        result = InputKeys.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        result = InputKeys.DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        result = InputKeys.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        result = InputKeys.RIGHT;
                        break;
                    case ConsoleKey.Escape:
                        result = InputKeys.EXIT;
                        break;
                }
            }
            return result;
        }

    }
}