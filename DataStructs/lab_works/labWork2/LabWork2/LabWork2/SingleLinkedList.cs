using System;
using System.Collections;

namespace LabWork2
{
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
        public Node First
        {
            get
            {
                return first;
            }
        }
        public SingleLinkedList()
        {
            first = null;
        }

        public void Create(int[] data)
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
        public void InsertBeforeFirst(int data)
        {
            Node p = new Node(data, first);
            first = p;
        }

        public void DeleteFirst()
        {
            if (first != null)
            {
                first = first.Link;
            }
        }

        public void InsertAfterLast(int data)
        {
            if (first == null)
            {
                first = new Node(data);
            }
            else
            {
                Node p = first;
                while (p.Link != null)
                {
                    p = p.Link;
                }
                p.Link = new Node(data);
            }
        }

        public void DeleteLast()
        {
            Node p = first;
            while (p.Link.Link != null)
            {
                p = p.Link;
            }
            p.Link = null;
        }

        public void InsertAt(int index,int  data)
        {
            if (index == 1)
            {
                if (first != null)
                {
                    first = first.Link;
                }
            }
            else
            {
                Node p = first;
                for (int i = 2; i < index; i++)
                {
                    p = p.Link;
                }
                p.Link = new Node(data, p.Link);
            }
        }

        public void DeleteAt(int index)
        {
            if (index == 1)
            {
                if (first != null)
                {
                    first = first.Link;
                }
            }
            else
            {
                Node p = first;
                for (int i = 2; i < index; i++)
                {
                    p = p.Link;
                }
                p.Link = p.Link.Link;
            }
        }

        public void Destroy()
        {
            first = null;
        }

        public void Processing(SingleLinkedList F2, SingleLinkedList F3)
        {
            if (F2.first != null)
            {
                Node p = first;
                Node p2 = F2.First;
                Node part_start = p;
                while (p != null)
                {
                    if (p.Info == p2.Info)
                    {
                        if (p2.Link != null)
                        {
                            p = p.Link;
                            p2 = p2.Link;
                        }
                        else
                        {
                            Node p3 = F3.first;
                            Node last = part_start;
                            while (p3 != null)
                            {
                                last.Link = new Node(p3.Info);
                                last = last.Link;
                                p3 = p3.Link;
                            }
                            last.Link = p.Link;
                        }
                    }
                    else
                    {
                        p = p.Link;
                        p2 = F2.First;
                        part_start = p;
                    }
                }
            }
        }
        public void DisplayInListBox(System.Windows.Forms.ListBox listBox)
        {
            listBox.Items.Clear();

            Node p = first;

            while (p != null)
            {
                listBox.Items.Add(p.Info);
                p = p.Link;
            }
        }
    }
}
