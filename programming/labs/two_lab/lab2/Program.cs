using System;

namespace lab2
{
    class Program()
    {
        static void MainTask()
        {
            double a;
            double b;
            Console.Write("Введите а: ");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Ошибка преобразования");
                Console.Write("Введите а: ");
            }
            Console.Write("Введите b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Ошибка преобразования");
                Console.Write("Введите b: ");
            }
            double result = -4 * Math.Pow(Math.Sin(a * 3), 3) + Math.Sqrt(b) / Math.Log(b + 2);
            if (result < 1.0 / 0.0) // проверка на бесконечность
            {
                double gues = 0;
                //Console.WriteLine($"результат: {result}");
                for (int i = 3; i > 0; i--)
                {
                    Console.Write($"попыток осталось: {i} \nВведите ответ: ");
                    while (!Double.TryParse(Console.ReadLine(), out gues))
                    {
                        Console.Write("ошибка ввода \nВведите ответ: ");
                    }
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
            else
            {
                Console.WriteLine("ошибка, используйте другие значения");
                MainTask();
            }
        }

        static int InputInt(string text)
        {
            int result = -1;
            Console.Write(text);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write(text);
            }
            return result;
        }

        static void AdditionalTask()
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

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("===== МЕНЮ ====");
                Console.WriteLine("1. Отгадай ответ");
                Console.WriteLine("2. Простой математический тест");
                Console.WriteLine("3. Об авторе");
                Console.WriteLine("4. Выход");
                Console.Write("Ввод:");
                switch (Console.ReadLine())
                {
                    case "1":
                        MainTask();
                        break;
                    case "2":
                        AdditionalTask();
                        break;
                    case "3":
                        Console.WriteLine("Кузнецов Дмитрий Анатольевич, группа: 6101-090301D");
                        break;
                    case "4":
                        Console.Write("выйти? (Д/Н): ");
                        bool? exit = null;
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
                                    Console.WriteLine("ошибка ввода");
                                    break;
                            }
                            if (exit == true)
                            {
                                isRunning = false;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }

            }
        }

    }
}