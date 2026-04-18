public class Node
{
    private int info;
    private Node link;
    public int Info
    {
        get { return info; }
        set { info = value; }
    }
    public Node Link
    {
        get { return link; }
        set { link = value; }
    }
    public Node() { }

    public Node(int info)
    {
        Info = info;
    }

    public Node(int info, Node link)
    {
        Info = info; Link = link;
    }
}
public class RecursiveList
{
    private Node first; // ссылка на первый узел списка
    public Node First // свойства для доступа к ссылке на первый узел списка
    {
        get { return first; }
        set { first = value; }
    }
    public RecursiveList() // конструктор
    {
        first = null;
    }

    public void PrintFront(Node first) // распечатка содержимого списка
    {
        // в прямом направлении; first – не поле класса, а формальный параметр функции –
        // ссылка на первый узел списка, этот параметр можно назвать как угодно
        if (first != null)
        {
            Console.WriteLine(first.Info);
            PrintFront(first.Link); // хвостовая рекурсия
        }
    }

    public void PrintBack(Node first)
    {
        if (first != null)
        {
            PrintBack(first.Link);
            Console.WriteLine(first.Info);
        }
    }

    public Node CreateRecursive(int n)
    {
        Node p = null;
        if (n > 0)
        {
            Console.Write($"введите значение для {n}: ");
            int i;
            string input = null;
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out i));
            p = new Node(i);
            p.Link = CreateRecursive(n - 1);
        }
        return p;
    }

    public int Count(Node p)
    {
        int result = 0;
        if(p != null)
        {
            result = Count(p.Link) +1;
        }
        return result;
    }

    public static void Main()
    {
        RecursiveList list = new RecursiveList();
        list.First = list.CreateRecursive(3);
        list.PrintFront(list.First);
        Console.WriteLine("-------------");
        list.PrintBack(list.First);
        Console.WriteLine(list.Count(list.First));
    }
}