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

    public void DeleteAll(int data)
    {
        if (head != null)
        {
            DoubleNode p = head.Next;
            while (p != head)
            {
                if (p.Info == data)
                {
                    p.Prev.Next = p.Next;
                    p.Next.Prev = p.Prev;
                }
                p = p.Next;
            }
        }
    }

    public void CreateOrdered(int[] data)
    {
        if (head != null)
        {
            for (int i = 0; i < data.Length; i++)
            {
                DoubleNode p = head.Next;
                while (p != head && p.Info <= data[i])
                {
                    p = p.Next;
                }
                DoubleNode n = new DoubleNode(data[i], p, p.Prev);
                p.Prev.Next = n;
                p.Prev = n;
            }
        }
    }

    public void Processing(CycleDoubleLinkedList F2, CycleDoubleLinkedList F3)
    {
        if (head != null)
        {
            DoubleNode p = head.Next;
            DoubleNode partStart = head.Next;
            DoubleNode q = F2.head.Next;
            while (p != head)
            {
                if (p.Info == q.Info)
                {
                    if (q.Next != F2.head)
                    {
                        p = p.Next;
                        q = q.Next;
                    }
                    else
                    {
                        DoubleNode p3 = F3.head.Next;
                        DoubleNode last = partStart.Prev;
                        while (p3 != F3.head)
                        {
                            DoubleNode n = new DoubleNode(p3.Info);
                            last.Next = n;
                            n.Prev = last;
                            last = n;
                            p3 = p3.Next;
                        }
                        last.Next = p.Next;
                        p.Next.Prev = last;
                        p = last.Next;
                    }
                }
                else
                {
                    partStart = partStart.Next;
                    p = partStart;
                    q = F2.head.Next;
                }
            }
        }
    }
    public static void Main()
    {
        CycleDoubleLinkedList F1 = new CycleDoubleLinkedList();
        F1.Create(new int[]{ 1,2,3,1,2,1,2,3,4,1,2,3});
        F1.Print();
        CycleDoubleLinkedList F2 = new CycleDoubleLinkedList();
        F2.Create(new int[] { 1, 2, 3});
        CycleDoubleLinkedList F3 = new CycleDoubleLinkedList();
        F3.Create(new int[] { 10,20 });

        F1.Processing(F2, F3);
        F1.Print();
    }
}