public class MultiNode
{
    private string fam;
    private double mark;
    private MultiNode fnext;
    private MultiNode fprev;
    private MultiNode mnext;
    private MultiNode mprev;
    public string Fam
    {
        get
        { 
            return fam; 
        }
        set
        {
            fam = value;
        }
    }
    public double Mark
    {
        get
        {
            return mark;
        }
        set
        {
            mark = value;
        }
    }
    public MultiNode Fnext
    {
        get
        {
            return fnext;
        }
        set
        {
            fnext = value;
        }
    }
    public MultiNode Fprev
    {
        get
        {
            return fprev;
        }
        set
        {
            fprev = value;
        }
    }
    public MultiNode Mnext
    {
        get
        {
            return mnext;
        }
        set
        {
            mnext = value;
        }
    }
    public MultiNode Mprev
    {
        get
        {
            return mprev;
        }
        set
        {
            mprev = value;
        }
    }
    public MultiNode() { }
    public MultiNode(string fam, double mark)
    { Fam = fam; Mark = mark; }
}

public class MultiLinkedList // Класс “Мультисписок”
{
    private MultiNode head; // ссылка на головной узел мультисписка
    public MultiLinkedList() // создание элементарного мультисписка
    {
        head = new MultiNode();
        head.Fnext = head;
        head.Fprev = head;
        head.Mnext = head;
        head.Mprev = head;
    }

    public void CreateMulty(string[] fams, int[] marks)
    {
        if (head != null)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                MultiNode p = head.Fnext;
                MultiNode n = new MultiNode(fams[i], marks[i]);
                while(p != head && string.Compare(n.Fam , p.Fam,true) > 0)
                {
                    p = p.Fnext;
                }
                n.Fprev = p.Fprev;
                n.Fnext = p;
                p.Fprev.Fnext = n;
                p.Fprev = n;
                p = head.Mnext;
                while (p != head && p.Mark > n.Mark)
                {
                    p = p.Mnext;
                }
                n.Mprev = p.Mprev;
                n.Mnext = p;
                p.Mprev.Mnext = n;
                p.Mprev = n;
            }
        }
    }

    public MultiNode Find(string fam)
    {
        MultiNode p = null;
        if (head != null)
        {
            p = head.Fnext;
            while(p != head && p.Fam  != fam)
            {
                p = p.Fnext;
            }
        }
        if(p == head)
        {
            p = null;
        }
        return p;
    }

    public void Delete(MultiNode n)
    {
        if(head != null && n != null)
        {
            n.Fprev.Fnext = n.Fnext;
            n.Fnext.Fprev = n.Fprev;

            n.Mprev.Mnext = n.Mnext;
            n.Mnext.Mprev = n.Mprev;
        }
    }
    public void PrintFam() // распечатка мультисписка,
    { // упорядоченного по алфавиту
        if (head != null) // список существует?
        {
            MultiNode p = head.Fnext; // установить вспомогательную ссылку
            while (p != head) // весь список пройден?
            { // распечатать информационные поля}
                Console.WriteLine(p.Fam + p.Mark);
                p = p.Fnext; // перейти к следующему узлу
            }
        }
    }
    public void PrintMark() // распечатка мультисписка,}
    { // упорядоченного по среднему баллу
        if (head != null) // список существует?
        {
            MultiNode p = head.Mnext; // установить вспомогательную ссылку
            while (p != head) // весь список пройден?
            { // распечатать информационные поля
                Console.WriteLine(p.Mark + p.Fam);
                p = p.Mnext; // перейти к следующему узлу
            }
        }
    }

    public static void Main()
    {
        MultiLinkedList list = new MultiLinkedList();
        list.CreateMulty(new string[]{ "борисов", "кузнецов","мацкевич" ,"муслимов"}, new int[]{ 3, 5, 4,2 });
        list.PrintFam();
        list.PrintMark();
        Console.WriteLine("----------");

        MultiNode tmp = list.Find("муслимов");
        list.Delete(tmp);
        list.PrintMark();
    }
}