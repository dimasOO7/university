namespace lab
{
    class Menu
    {

        public static int MenuSelection(string[] menuItems, string menuText = "========= МЕНЮ =========")
        {
            int selectedItem = 0;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(menuText);
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItem)
                    {
                        Console.Write("=> ");
                    }
                    Console.WriteLine($"{i + 1} {menuItems[i]}");
                }
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        selectedItem = ++selectedItem % menuItems.Length;
                        break;

                    case ConsoleKey.UpArrow:
                        selectedItem = (selectedItem + menuItems.Length - 1) % menuItems.Length;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.CursorVisible = true;
                        return selectedItem;

                }
            }
        }
    }
}