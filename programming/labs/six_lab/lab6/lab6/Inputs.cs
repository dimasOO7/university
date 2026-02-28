namespace lab
{
    /// <summary>
    /// статический класс содержащий функции ввода
    /// </summary>
    static class Inputs
    { 
        /// <summary>
        /// функция для ввода целого числа
        /// </summary>
        /// <param name="text"> текст выводящийся перед вводом</param>
        /// <param name="checkZero"> проверять ли на то что число > 0</param>
        /// <returns>введённое число</returns>
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
        /// <summary>
        /// Функция ввода вещественного числа
        /// </summary>
        /// <param name="text">текст выводящийся перед вводом</param>
        /// <returns>введённое число</returns>
        public static double InputDouble(string text)
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
    }
}