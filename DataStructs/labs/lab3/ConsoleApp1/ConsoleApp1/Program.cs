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

public class SingleLinkedList
{
    private Node first;
    public SingleLinkedList()
    {
        first = null;
    }

    public void InsertBeforeFirst(int data)
    {
        Node p = new Node(data,first);
        first = p;
    }
    
    public void Create1(int[] data)
    {
        first = null;
        for (int i = 0; i < data.Length; i++)
        {
            Node p = new Node(data[i], first);
            first = p;
        }
    }

    public void Create2(int[] data)
    {
        if (data.Length == 0) first = null;
        else
        {
            first = new Node(data[0], null);
            Node last = first;
            for (int i = 1; i < data.Length; i++)
            {
                Node p = new Node(data[i], null);
                last.Link = p;
                last = p;
            }
        }
    }

    public void DeleteFirst1()
    {
        if (first != null)
        {
            first = first.Link;
        }
    }
    public Node DeleteFirst2()
    {
        Node p = null;
        if (first != null)
        {
            p = first;
            first = first.Link;
        }
        return p;
    }
    public void Print()
    {
        Node p = first;
        while (p != null)
        {
            Console.WriteLine(p.Info);
            p = p.Link;
        }
    }

    public int Count()
    {
        int count = 0;
        Node p = first;
        while (p != null)
        {
            count++;
            p = p.Link;
        }
        return count;
    }

    public bool IsSorted()
    {
        bool isSorted = true;
        Node p = first;
        while (p != null && isSorted)
        {
            Node next = p.Link;
            if(next != null)
            {
                isSorted = next.Info > p.Info;
            }
            p = next;
        }
        return isSorted;
    }

    public Node Find(int n)
    {
        Node p = first;
        while (p != null && p.Info != n)
        {
            p = p.Link;
        }
        return p;
    }

    public void InsertAfter(Node target,int data)
    {
        if(target != null)
        {
            Node newNode = new Node(data, target.Link);
            target.Link = newNode;
        }
    }

    public void DeleteAfter1(Node target)
    {
        if(target != null && target.Link != null)
        {
            target.Link = target.Link.Link;
        }
    }
    public Node DeleteAfter2(Node target)
    {
        Node p = null;
        if (target != null && target.Link != null)
        {
            p = target.Link;
            target.Link = p.Link;
        }
        return p;
    }

    public void DeleteCurrent(ref Node t)
    {
        if (t != null)
        {
            if(t == first)
            {
                first = t.Link;
            }
            else
            {
                Node p = first;
                while (p != null && p.Link != t)
                {
                    p = p.Link;
                }
                if (p != null)
                {
                    p.Link = t.Link;
                }
            }
        }

        t = null;
    }
    public static void Main()
    {
        SingleLinkedList L = new SingleLinkedList();
        //L.InsertBeforeFirst(10);
        //L.Print();
        //Console.ReadKey();
        //Console.WriteLine("");
        //L.Create1(new int[] { 1, 2, 3 });
        //L.Print();
        //Console.ReadKey();
        //Console.WriteLine("");
        L.Create2(new int[] { 10, 20, 30 });
        L.Print();
        Console.ReadKey();
        Console.WriteLine("");
        //L.DeleteFirst1();
        //L.Print();
        //Console.ReadKey();
        //Console.WriteLine("");
        //Node Deleted = L.DeleteFirst2();
        //L.Print();
        //Console.ReadKey();
        //Console.WriteLine("");
        //Console.WriteLine(Deleted.Info);
        //Console.WriteLine(L.Count());
        //Console.ReadKey();
        //Console.WriteLine("");
        //Console.WriteLine(L.IsSorted());
        //Console.ReadKey();
        //Console.WriteLine("");
        Node p = L.Find(20);
        L.InsertAfter(p,25);
        L.Print();
        Console.ReadKey();
        Console.WriteLine("");
        //Node q =L.DeleteAfter2(p);
        Node q = L.Find(30);
        L.DeleteCurrent(ref q);
        L.Print();
        Console.ReadKey();
        //Console.WriteLine(q.Info);
    }
}