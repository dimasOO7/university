public class TreeNode // Класс «Узел бинарного дерева»
{
    private char info; // информационное поле
    private TreeNode left; // ссылка на левое поддерево
    private TreeNode right; // ссылка на правое поддерево
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
    public TreeNode Left 
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
    public TreeNode Right
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
    public TreeNode() { } // конструкторы
    public TreeNode(char info)
    {
        Info = info;
    }
    public TreeNode(char info, TreeNode left, TreeNode right)
    {
        Info = info; Left = left; Right = right;
    }
}
public class BinaryTree
{
    private TreeNode root;
    public TreeNode Root // свойство, открывающее доступ к корню дерева
    {
        get { return root; }
        set { root = value; }
    }
    public BinaryTree() // инициализация пустого дерева
    {
        root = null;
    }
    
    public void LKP(TreeNode root)
    {
        if(root != null)
        {
            LKP(root.Left);
            Console.WriteLine(root.Info);
            LKP(root.Right);
        }
    }

    public int Count(TreeNode root)
    {
        int count;
        if (root == null)
        {
            count = 0;
        }
        else
        {
            count = Count(root.Left) + Count(root.Right) +1;
        }
        return count;

    }

    public TreeNode CreateBalanced(int i)
    {
        TreeNode root;
        if(i == 0)
        {
            root = null;
        }
        else
        {
            Console.Write("\nвведите инф. поле: ");
            root = new TreeNode(Console.ReadKey().KeyChar);
            root.Left = CreateBalanced(i / 2);
            root.Right = CreateBalanced(i - i / 2 - 1);
        }
        return root;
    }

    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Root = tree.CreateBalanced(7);
        Console.WriteLine(tree.Count(tree.Root));
        tree.LKP(tree.Root);
    }
}
