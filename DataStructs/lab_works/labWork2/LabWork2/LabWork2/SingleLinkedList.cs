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

        public void InsertBeforeFirst(int data)
        {
            Node p = new Node(data, first);
            first = p;
        }

        public bool DeleteFirst()
        {
            bool success = false;
            if (first != null)
            {
                first = first.Link;
                success = true;
            }
            return success;
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

        public bool DeleteLast()
        {
            bool success = false;
            if (first != null)
            {
                Node p = first;
                while (p.Link.Link != null)
                {
                    p = p.Link;
                }
                p.Link = null;
                success = true;
            }
            return success;
        }

        public bool InsertAt(int index,int  data)
        {
            bool success = false;
            if (index == 1)
            {
                first = new Node(data, first);
                success = true;
            }
            else
            {
                Node p = first;
                int i = 2;
                while (i < index && p != null)
                {
                    p = p.Link;
                    i++;
                }
                if (p != null)
                {
                    p.Link = new Node(data, p.Link);
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteAt(int index)
        {
            bool success = false;
            if (index > 0)
            {
                if (index == 1)
                {
                    if (first != null)
                    {
                        first = first.Link;
                        success = true;
                    }
                }
                else
                {
                    Node p = first;
                    int i = 2;
                    while(i < index && p != null)
                    {
                        p = p.Link;
                        i++;
                    }
                    if (p != null)
                    {
                        p.Link = p.Link.Link;
                        success = true;
                    }
                }
            }
            return success;
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
                Node partStart = null;
                Node prev = null;
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
                            Node last;
                            if (partStart == null)
                            {
                                first = new Node(p3.Info,first.Link);
                                last = first;
                                p3= p3.Link;
                            }
                            else
                            {
                                last= partStart;
                            }
                            while (p3 != null)
                            {
                                last.Link = new Node(p3.Info);
                                last = last.Link;
                                p3 = p3.Link;
                            }
                            last.Link = p.Link;
                            p = p.Link;
                        }
                    }
                    else
                    {
                        if (p2 == F2.First)
                        {
                            prev = p;
                            partStart = p;
                            p = p.Link;
                        }
                        else
                        {
                            if (prev == null)
                            {
                                partStart = first;
                                prev = first;
                            }
                            else
                            {
                                partStart = prev.Link;
                            }
                            p = partStart.Link;
                        }
                        p2 = F2.First;
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
