public class DTreeNode // Класс «Узел дихотомического дерева»
{
    private char info; // информационное поле
    private int key; // поле ключа
    private DTreeNode left; // ссылка на левое поддерево
    private DTreeNode right; // ссылка на правое поддерево
    public char Info
    {
        get
        { 
            return info; 
        }
        set
            {
            info = value;
        }
    }
    public int Key
    {
        get
        {
            return key;
        }
        set
        {
            key = value;
        }
    }
    public DTreeNode Left
    {
        get
        {
            return left;
        }
        set
        {
            left = value;
        }
    }
    public DTreeNode Right
    {
        get
        {
            return right;
        }
        set
        {
            right = value;
        }
    }
    public DTreeNode() { } // конструкторы
    public DTreeNode(char info, int key)
    {
        Info = info; Key = key;
    }
    public DTreeNode(char info, int key, DTreeNode left, DTreeNode right)
    {
        Info = info; Key = key; Left = left; Right = right;
    }
}
public class DichotomyTree // класс «Дихотомическое дерево»
{
    private DTreeNode root; // ссылка на корень дихотомического дерева
    public DTreeNode Root // свойство, открывающее доступ к корню дерева
    {
        get { return root; }
        set { root = value; }
    }
    public DichotomyTree() // инициалиазция пустого дерева
    {
        root = null;
    }

    public DTreeNode Find(DTreeNode root, int key)
    {
        DTreeNode result;
        if (root == null)
        {
            result = null;
        }
        else
        {
            if (root.Key == key)
            {
                result = root;
            }
            else
            {
                if (root.Key < key)
                {
                    result = Find(root.Left, key);

                }
                else
                {
                    result = Find(root.Right, key);
                }
            }
        }
        return result;
    }

    public DTreeNode Insert(DTreeNode root, int key)
    {
        if (root == null)
        {
            if (this.Root == null)
            {
                root = new DTreeNode();
                root.Key = key;
                Console.Write("\nвведите инф поле:");
                root.Info = Console.ReadKey().KeyChar;
                this.root = root;
            }
            else
            {
                root = new DTreeNode();
                root.Key = key;
                Console.Write("\nвведите инф поле:");
                root.Info = Console.ReadKey().KeyChar;
            }
        }
        else
        {
            if (root.Key < key)
            {
                root.Left = Insert(root.Left, key);

            }
            else
            {
                root.Right = Insert(root.Right, key);
            }
        }
        return root;
    }


    static void Main()
        { 
        DichotomyTree T1 = new DichotomyTree();
        T1.Insert(T1.Root,10);
        DTreeNode p = T1.Find(T1.Root,10);
        if (p == null)
        {
            Console.WriteLine("узел не найден");
        }
        else
        {
            Console.WriteLine(p.Info);
        }
    }
}
