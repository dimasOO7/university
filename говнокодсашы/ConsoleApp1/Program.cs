using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        bool run = true;
        while (run)
        {
            Console.Write("=======МЕНЮ======= \n1.Отгадай ответ \n2.Об авторе \n3.Выход \nВведите ваш выбор(1-3):");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Ошибка ввода, введите число от 1 до 3");
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите число А");
                    int a;
                    int b;
                    while (int.TryParse(Console.ReadLine(), out a)==false)
                    {
                        Console.WriteLine("Ошибка ввода, введите целое число:");
                    }
                    Console.WriteLine("Введите число Б");
                    while (!int.TryParse(Console.ReadLine(), out b) || b == 0)
                    {
                        Console.WriteLine("Ошибка ввода, введите целое число, не равное нулю:");
                    }
                    Console.WriteLine("Попробуйте угадать результат, с точностью до 2 знаков после запятой за 3 попытки");
                    double numerator = Math.Log(Math.Pow(b, 5));
                    double denominator = Math.Sin(a) + 1;
                    double result = Math.PI * (numerator / denominator);
                    result = Math.Round(result, 2);
                    double att;
                    Console.WriteLine(result);
                    for (int i = 3; i > 0; i--)
                    {
                        while (!double.TryParse(Console.ReadLine(), out att))
                        {
                            Console.WriteLine("Ошибка ввода, введите число:");
                        }
                        if (result == att)
                        {
                            Console.WriteLine("Поздравляю вы угадали");
                            i = 0;
                        }
                        else
                        {
                            Console.WriteLine("Вы не угадали попробуйте снова \nКоличество оставшихся попыток: {0}", i - 1);
                        }
                    }
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.Read();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Гильфанов Александр Александрович, группа: 6101-090301D");
                    Console.WriteLine("Чтобы вернуться в главное меню нажмите на любую кнопку");
                    Console.Read();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Вы действительно хотите выйти? \nд/н");
                    string exit = Console.ReadLine();
                    while (exit != "д" && exit != "н")
                    {
                        Console.Write("Ошибка ввода, введите д/н:");
                        exit = Console.ReadLine();
                    }
                    if (exit == "д")
                        run = false;
                    else if (exit == "н")
                        Console.Clear();
                    break;
                default:
                    Console.WriteLine("Ошибка ввода, введите число от 1 до 3");
                    break;
            }
        }


    }
}