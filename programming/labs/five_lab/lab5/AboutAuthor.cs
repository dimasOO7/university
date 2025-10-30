namespace lab
{
    static class AboutAuthor
    {
        const string AuthorInformation = "Кузнецов Дмитрий Анатольевич, группа: 6101-090301D";
        /// <summary>
        /// Выводит информацию об авторе
        /// </summary>
        public static void DisplayInformation()
        {
            Console.WriteLine(AuthorInformation);
        }
    }
}