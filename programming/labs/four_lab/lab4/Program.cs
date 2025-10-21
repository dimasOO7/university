using System;

namespace lab
{

    class Program()
    {
        public static int InputInt(string text, bool checkZero = false)
        {
            int result = -1;
            Console.Write(text);
            do
            {
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Ошибка ввода");
                    Console.Write(text);
                }
            } while (checkZero && result <= 0);
            return result;
        }

        static double InputDouble(string text)
        {
            double result = -1;
            Console.Write(text);
            while (!Double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write(text);
            }
            return result;
        }
        static double CalculateFunction(double a, double b)
        {   
            double result = -4 * Math.Pow(Math.Sin(a * 3), 3) + Math.Sqrt(b) / Math.Log(b + 2);
            while (!(result < 1.0 / 0.0)) // проверка на бесконечность
            {
                Console.WriteLine("ошибка, используйте другие значения");
                CalculateFunction(InputDouble("Введите а: "), InputDouble("Введите b: "));
            }
            return result;
        }
        static void GuessAnswer(double result)
        {
            
            double gues = 0;
            //Console.WriteLine($"результат: {result}");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"попыток осталось: {i}");
                gues = InputDouble("Введите ответ:");
                if (gues == result)
                {
                    Console.WriteLine($"Верно \nосталось {i} попыток");
                    i = 0;
                }
                else
                {
                    Console.WriteLine("Неверно");
                }
            }
            if (gues == result)
            {
                Console.WriteLine("Молодец, ты победил");
            }
            else
            {
                Console.WriteLine("GameOver");
                Console.WriteLine($"Верный ответ был: {result}");
            }
        }

        static void MathTest()
        {
            Random rnd = new();
            int trueGueses = 0;
            int result = 0;
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Осталось {i} заданий\n верных ответов: {trueGueses}");
                int a = rnd.Next(1, 10);
                int b = rnd.Next(1, 10);
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        result = a + b;
                        if (InputInt($"{a} + {b} = ") == result)
                        {
                            Console.WriteLine("Верно");
                            trueGueses++;
                        }
                        else
                        {
                            Console.WriteLine($"Неверно, верный ответ: {result}");
                        }
                        break;
                    case 2:
                        result = a - b;
                        if (InputInt($"{a} - {b} = ") == result)
                        {
                            Console.WriteLine("Верно");
                            trueGueses++;
                        }
                        else
                        {
                            Console.WriteLine($"Неверно, верный ответ: {result}");
                        }
                        break;
                    case 3:
                        result = a * b;
                        if (InputInt($"{a} * {b} = ") == result)
                        {
                            Console.WriteLine("Верно");
                            trueGueses++;
                        }
                        else
                        {
                            Console.WriteLine($"Неверно, верный ответ: {result}");
                        }
                        break;
                }
            }
            Console.WriteLine($"Конец\nВерных ответов: {trueGueses}");
        }

        static void AboutAuthor()
        {
            Console.WriteLine("Кузнецов Дмитрий Анатольевич, группа: 6101-090301D");
        }

        static bool ExitCheck()
        {
            bool? exit = null;
            Console.Write("выйти? (Д/Н): ");
            while (exit == null)
            {
                switch (Console.ReadLine())
                {
                    case "Д":
                        exit = true;
                        break;
                    case "Н":
                        exit = false;
                        break;
                    case "д":
                        exit = true;
                        break;
                    case "н":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("ошибка ввода \nвыйти? (Д/Н): ");
                        break;
                }
            }
            return (bool)exit;
        }

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
                        GuessAnswer(CalculateFunction(InputDouble("Введите а: "), InputDouble("Введите b: ")));
                        break;
                    case 1:
                        MathTest();
                        break;
                    case 2:
                        AboutAuthor();
                        break;
                    case 3:
                        ArraySorter.DoTask();
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