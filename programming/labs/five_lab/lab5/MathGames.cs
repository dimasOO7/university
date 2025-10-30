namespace lab
{
    class MathGames
    {
        private static double CalculateFunction(double a, double b)
        {
            double result = -4 * Math.Pow(Math.Sin(a * 3), 3) + Math.Sqrt(b) / Math.Log(b + 2);
            while (!(result < 1.0 / 0.0)) // проверка на бесконечность
            {
                Console.WriteLine("ошибка, используйте другие значения");
                CalculateFunction(Inputs.InputDouble("Введите а: "), Inputs.InputDouble("Введите b: "));
            }
            return result;
        }
        /// <summary>
        /// Запускает игру по отгадыванию ответа
        /// </summary>
        public static void GuessAnswer()
        {
            double result = CalculateFunction(Inputs.InputDouble("Введите а: "), Inputs.InputDouble("Введите b: "));
            double gues = 0;
            //Console.WriteLine($"результат: {result}");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"попыток осталось: {i}");
                gues = Inputs.InputDouble("Введите ответ:");
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
        /// <summary>
        /// запускает простой математический тест
        /// </summary>
        public static void MathTest()
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
                        if (Inputs.InputInt($"{a} + {b} = ") == result)
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
                        if (Inputs.InputInt($"{a} - {b} = ") == result)
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
                        if (Inputs.InputInt($"{a} * {b} = ") == result)
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
    }
}