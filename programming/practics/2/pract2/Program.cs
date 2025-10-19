using System;

namespace pract2
{
	class Program
	{
		static void Main(string[] args)
		{
			int age = 0;
			Console.WriteLine("Введите ваш возраст");
			string strAge = Console.ReadLine();
			bool is_correct = false;
			is_correct = int.TryParse(strAge, out age);
			if (is_correct)
			{
				Console.WriteLine($"ты ввёл число: {age}");
			}
			else
			{
				Console.WriteLine("пу пу пу");
			}
		}
	}
}