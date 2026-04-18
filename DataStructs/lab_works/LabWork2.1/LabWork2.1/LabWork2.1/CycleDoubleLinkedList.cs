using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LabWork2._1
{
    public class DoubleNode
    {
        private int info;
        private DoubleNode next;
        private DoubleNode prev;
        public int Info
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
    internal class CycleDoubleLinkedList
    {
        private DoubleNode head;
        public CycleDoubleLinkedList()
        {
            head = new DoubleNode();
            head.Next = head;
            head.Prev = head;
        }

        public void InsertFirst(int data)
        {
            DoubleNode p = new DoubleNode(data);
            p.Prev = head;
            p.Next = head.Next;
            head.Next.Prev = p;
            head.Next = p;
        }

        public void InsertLast(int data)
        {
            DoubleNode p = new DoubleNode(data);
            p.Next = head;
            p.Prev = head.Prev;
            head.Prev.Next = p;
            head.Prev = p;
        }

        public bool InsertAt(int index, int data)
        {
            bool success = false;
            DoubleNode p = head.Next;
            int i = 1;
            while (i < index && p != head)
            {
                p = p.Next;
                i++;
            }
            if(p!=head)
            {
                DoubleNode n = new DoubleNode(data);
                n.Prev = p;
                n.Next = p.Next;
                p.Next.Prev = n;
                p.Next = n;
                success = true;
            }
            return success;
        }
        public bool DeleteFirst()
        {
            bool success = false;
            if(head.Next != head)
            {
                success = true;
                head.Next.Prev = head;
                head.Next = head.Next.Next;
            }
            return success;
        }

        public bool DeleteLast()
        {
            bool success = false;
            if (head.Prev != head)
            {
                success = true;
                head.Prev.Next = head;
                head.Prev = head.Prev.Prev;
            }
            return success;
        }
        public bool DeleteAt(int index)
        {
            bool success = false;
            DoubleNode p = head.Next;
            int i = 1;
            while (i < index && p != head)
            {
                p = p.Next;
                i++;
            }
            if (p != head)
            {
                p.Next = p.Next.Next;
                p.Next.Prev = p;
                success = true;
            }
            return success;
        }
        public void Create(int[] dates)
        {
            head = new DoubleNode();
            head.Next = head;
            head.Prev = head;
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

        public void Clear()
        {
            head = new DoubleNode();
            head.Next = head;
            head.Prev = head;
        }

        public int Count()
        {
            int count = 0;
            DoubleNode p = head.Next;
            while(p != head)
            {
                count++;
                p = p.Next;
            }
            return count;
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

        public void DisplayInListBox(System.Windows.Forms.ListBox listBox)
        {
            listBox.Items.Clear();

            DoubleNode p = head.Next;

            while (p != null)
            {
                listBox.Items.Add(p.Info);
                p = p.Next;
            }
        }
    }
}
