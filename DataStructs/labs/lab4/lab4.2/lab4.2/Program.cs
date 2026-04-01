using static System.Runtime.InteropServices.JavaScript.JSType;

public class DoubleNode
{
    private int info;
    private DoubleNode next;
    private DoubleNode prev;
    public int Info {
        get
        {
            return info;
        }
        set
        {
            info = value;
        }
}
    public DoubleNode Next
    {
        get
        {
            return next;
        }
        set
        {
            next = value;
        }
    }
    public DoubleNode Prev
    {
        get
        {
            return prev;
        }
        set
        {
            prev = value;
        }
    }
    public DoubleNode() { }
    public DoubleNode(int info)
    {
        Info = info;
    }
    public DoubleNode(int info, DoubleNode next, DoubleNode prev)
    {
        Info = info; Next = next; Prev = prev;
    }
}

public class CycleDoubleLinkedList
{
    private DoubleNode head;
    public CycleDoubleLinkedList()
    {
        head = new DoubleNode();
        head.Next = head;
        head.Prev = head;
    }

    public void Print()
    {
        Console.WriteLine("---------");
        if (head != null)
        {
            DoubleNode p = head.Next;
            while (p != head)
            {
                Console.WriteLine(p.Info);
                p = p.Next;
            }
        }
    }

    public DoubleNode Find(int value)
    {
        DoubleNode p = null;
        if (head != null)
        {
            p = head.Next;
            while (p != head && p.Info != value)
            {
                p = p.Next;
            }
            if (p == head)
            {
                p = null;
            }
        }
        return p;
    }

    public void InsertRight(DoubleNode p, int data)
    {
        DoubleNode q;
        if (p != null)
        {
            q = new DoubleNode(data);
            q.Next = p.Next;
            q.Prev = p;
            p.Next.Prev = q;
            p.Next = q;
        }
    }
    public void InsertLeft(DoubleNode p, int data)
    {
        DoubleNode q;
        if (p != null)
        {
            q = new DoubleNode(data);
            q.Next = p;
            q.Prev = p.Prev;
            p.Prev.Next = q;
            p.Prev = q;
        }
    }
    public void Create(int[] dates)
    {
        DoubleNode p;
        for (int i = 0; i < dates.Length; i++)
        {
            p = new DoubleNode(dates[i]);
            p.Next = head;
            p.Prev = head.Prev;
            head.Prev.Next = p;
            head.Prev = p;
        }
    }

    public void Delete(DoubleNode p)
    {
        if (p != null && p != head)
        {
            p.Prev.Next = p.Next;
            p.Next.Prev = p.Prev;
        }
    }
    public void Delete1(ref DoubleNode p)
    {
        if (p != null && p != head)
        {
            p.Prev.Next = p.Next;
            p.Next.Prev = p.Prev;
        }
        p = null;
    }


    public static void Main()
    {
        CycleDoubleLinkedList L = new CycleDoubleLinkedList();
        L.Create(new int[]{ 1, 2, 3,4,5});
        L.Print();
        DoubleNode tmp = L.Find(3);
        if (tmp != null)
        {
            L.InsertRight(tmp, 10);
            L.InsertLeft(tmp, 20);
            L.Print();
        }
        L.Delete1(ref tmp);
        L.Print();
        Console.WriteLine(tmp.Info);

    }
}