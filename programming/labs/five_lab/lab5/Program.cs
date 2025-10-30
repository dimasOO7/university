using System;

namespace lab
{

    class Program()
    {

        static void Main(string[] args)
        {
            bool isRunning = true;
            Console.WriteLine();

            while (isRunning)
            {
                //Console.SetCursorPosition(0,0);
                Console.Clear();
                switch (Menu.MenuSelection(["Отгадай ответ", "Простой математический тест", "Об авторе", "Сортировка массива", "Угашенный червяк", "Выход"]))
                {
                    case 0:
                        MathGames.GuessAnswer();
                        break;
                    case 1:
                        MathGames.MathTest();
                        break;
                    case 2:
                        AboutAuthor.DisplayInformation();
                        break;
                    case 3:
                        int arraySize = Inputs.InputInt("Введите размер массива: ", true);
                        ArraySorter arraySorter;
                        if (arraySize == 10)
                        {
                            arraySorter = new ArraySorter();
                        }
                        else
                        {
                            arraySorter = new ArraySorter(arraySize);
                        }
                        arraySorter.DoTask();
                        break;
                    case 4:
                        Snake snake = new Snake();
                        snake.RunGame();
                        break;
                    case 5:
                        isRunning = Menu.MenuSelection(["нет", "да"], "Выйти?") == 0;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
        }

    }
}