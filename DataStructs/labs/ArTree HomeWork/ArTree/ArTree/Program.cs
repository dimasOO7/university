public class ArNode // Класс «Узел дерева арифметических выражений»
{
    private double info; // значение операнда в терминальном узле
    private char pr; // признак операции
    private ArNode left; // ссылка на левое поддерево
    private ArNode right; // ссылка на правое поддерево
                          // свойства,

    public double Info
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

    public ArNode Left
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

    public ArNode Right
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

    public char Pr
    {
        get
        {
            return pr;
        }
        set
        {
            pr = value;
        }
    }


    public ArNode() { }
    public ArNode(double info, char pr)
    { Info = info; Pr = pr; }
    public ArNode(double info, char pr, ArNode left, ArNode right)
    { Info = info; Pr = pr; Left = left; Right = right; }
}

public class ArTree
{
    private ArNode root;
    public ArNode Root
    {
        get
        { return root; }
        set
        { root = value; }
    }
    public ArTree()
    {
        root = null;
    }

    public double Calculate(ArNode root)
    {
        double result;
        if (root == null)
        {
            result = 0;
        }
        else
        {
            if (root.Pr == 'n')
            {
                result = root.Info;
            }
            else if (root.Pr == '+')
            {
                result = Calculate(root.Left) + Calculate(root.Right);
            }
            else if (root.Pr == '-')
            {
                result = Calculate(root.Left) - Calculate(root.Right);
            }
            else if(root.Pr == '*')
            {
                result = Calculate(root.Left) * Calculate(root.Right);
            }
            else if(root.Pr == '/')
            {
                result = Calculate(root.Left) / Calculate(root.Right);
            }
            else
            {
                result = 0;
            }
        }
        return result;
    }
}