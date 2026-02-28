using System;

class Entry
{
    public string Family {get;set;}
    public long PhoneNumber {get;set;}

    public Entry(string family, long phoneNumber)
    {
        Family = family;
        PhoneNumber = phoneNumber;
    }
}

class Page
{
    public char FirstCharacter {get;}
    private Entry[] entries;

    public Entry[] Entries
    {
        get
        {
            return entries;
        }
        set
        {
            entries = value;
        }
    }

    public int Count {get; set;}

    public Page(char firstCharacter,int capacity = 3)
    {
        Count = 0;
        FirstCharacter = firstCharacter;
        entries = new Entry[capacity];
    }

    public void AddEntry(Entry entry)
    {
        if(Count < entries.Length)
        {
            entries[Count] = entry;
            Count++;
        }
        else
        {
            throw new IndexOutOfRangeException("Переполнение массива записей");
        }
    }
}

class NoteBook
{
    private Page[] pages;

    public Page[] Pages
    {
        get
        {
            return pages;
        }
        set
        {
            pages = value;
        }
    }

    public int Count {get; set;}

    public NoteBook(int capacity = 3)
    {
        pages = new Page[capacity];
    }

    public void AddPage(Page page)
    {
        if(Count < pages.Length)
        {
            pages[Count] = page;
            Count++;
        }
        else
        {
            throw new IndexOutOfRangeException("Переполнение массива страниц");
        }
    }

    public bool GetNumberByFamily(string family, out long number)
    {
        foreach(Page page in Pages)
        {
            if(page != null && page.FirstCharacter == family[0])
            {
                foreach(Entry entry in page.Entries)
                {
                    if(entry != null && entry.Family == family)
                    {
                        number = entry.PhoneNumber;
                        return true;
                    }
                }
            }
        }

        number = 0;
        return false;
    }
}

class Program
{
    static void Main()
    {
        Entry entry1  = new Entry("Kuznetsov",      1234567890L);
        Entry entry2  = new Entry("Kamnev",   9534781264L);
        Entry entry3  = new Entry("Klevtsov",      0987456321L);
        Entry entry4  = new Entry("Manturov",  56321478901L);
        Entry entry5  = new Entry("Matzkiewicz",      4563258971L);
        Entry entry6  = new Entry("Muslimov",      96325874102L);
        Entry entry7  = new Entry("Makarov",      2354678791L);
        Entry entry8  = new Entry("Gavrilov",      1235478931L);
        Entry entry9  = new Entry("Groshev",      5632589412L);
        Entry entry10 = new Entry("Gerasimov",      1268745621L);

        Page page1 = new Page('K');
        page1.AddEntry(entry1);
        page1.AddEntry(entry2);
        page1.AddEntry(entry3);

        Page page2 = new Page('M',4);
        page2.AddEntry(entry4);
        page2.AddEntry(entry5);
        page2.AddEntry(entry6);
        page2.AddEntry(entry7);

        Page page3 = new Page('G');
        page3.AddEntry(entry8);
        page3.AddEntry(entry9);
        page3.AddEntry(entry10);

        NoteBook book = new NoteBook(3);

        book.AddPage(page1);
        book.AddPage(page2);
        book.AddPage(page3);

        Console.Write("введите фамилию: ");
        string family = Console.ReadLine();

        long number;

        if(!book.GetNumberByFamily(family, out number))
        {
            Console.WriteLine("Фамилия не найдена");
        }
        else
        {
            Console.WriteLine($"номер телефона {family}: {number}");
        }
    }
}