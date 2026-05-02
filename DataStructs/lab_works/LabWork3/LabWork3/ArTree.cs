using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace LabWork3
{
    public class ArNode // Класс «Узел дерева арифметических выражений»
    {
        private char info; // значение операнда в терминальном узле
        private ArNode left; // ссылка на левое поддерево
        private ArNode right; // ссылка на правое поддерево
                              // свойства,

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
        public ArNode() 
        {
        }
        public ArNode(char info)
        { 
            Info = info;;
        }
        public ArNode(char info, ArNode left, ArNode right)
        { 
            Info = info;
            Left = left; 
            Right = right;
        }
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

        public void Destroy()
        {
            Root = null;
        }

        public ArNode Create(string f)
        {
            ArNode result;
            if(f == null || f == "")
            {
                result = null;
            }
            else
            {
                if (f.Length == 1)
                {
                    if (!"+-*".Contains(f[0]))
                    {
                        result = new ArNode(f[0]);
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод, формула состоящая только из оператора");
                        result = null;
                    }
                }
                else
                {
                    int level = 0;
                    int i = 0;
                    while (level != 1 || !"+-*".Contains(f[i]))
                    {
                        if (f[i] == '(')
                        {
                            level++;
                        }
                        else if (f[i] == ')')
                        {
                            level--;
                        }
                        i++;
                    }
                    result = new ArNode(f[i]);
                    result.Left = Create(f.Substring(1, i - 1));
                    result.Right = Create(f.Substring(i + 1, f.Length - i - 2));

                    char operand = f[i];
                    if (operand == '+')
                    {
                        if (result.Left != null && result.Left.Info == '0')
                        {
                            result = result.Right;
                        }
                        else if (result.Right != null && result.Right.Info == '0')
                        {
                            result = result.Left;
                        }
                    }
                    else if(operand == '-')
                    {
                         if (result.Right != null && result.Right.Info == '0')
                        {
                            result = result.Left;
                        }
                    }
                    else
                    {
                        if ((result.Left != null && result.Left.Info == '0') || (result.Right != null && result.Right.Info == '0'))
                        {
                            result = new ArNode('0');
                        }
                        else if(result.Left != null && result.Left.Info == '1')
                        {  
                            result = result.Right; 
                        }
                        else if(result.Right != null && result.Right.Info == '1')
                        {
                            result = result.Left;
                        }
                    }
                }
            }
            return result;
            
        }
    }
}
