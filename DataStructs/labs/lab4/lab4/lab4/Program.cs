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

public class CycleSingleLinkedList
{
    private Node head;
    public CycleSingleLinkedList()
    {
        head = new Node();
        head.Link = head;

    }
    public void Create1(int[] dates)
    { 
        for (int i = 0; i < dates.Length; i++)
        {
            Node p = new Node(dates[i]);
            p.Link = head.Link;
            head.Link = p;
        }
    }

    public void Create2(int[] dates)
    {
        Node p, last;
        if (head != null)
        {
            last = head;
            for (int i = 0; i < dates.Length; i++)
            {
                p = new Node(dates[i]);
                p.Link = head;
                last.Link = p;
                last = p;
            }
        }
    }

    public void DeleteFirst()
    {
        if (head != null)
        {
            head.Link = head.Link.Link;
        }
    }

    public void DeleteEqual()
    {
        if (head != null)
        {
            Node p = head.Link;
            while (p.Link != head)
            {
                Node q = p;
                while (q.Link != head)
                {
                    if (q.Link.Info == p.Info)
                    {
                        q.Link = q.Link.Link;
                    }
                    else
                    {
                        q = q.Link;
                    }
                }
                p = p.Link;
            }
        }
    }
    public void Print()
    {
        Console.WriteLine("----------");
        if (head != null)
        {
            Node p = head.Link;
            while (p != head)
            {
                Console.WriteLine(p.Info);
                p = p.Link;
            }
        }
    }




    public static void Main()
    {
        CycleSingleLinkedList L = new CycleSingleLinkedList();
        L.Create2(new int[] { 1, 2, 3,3,2,1,2 });
        L.DeleteEqual();
        L.Print();
    }
}

