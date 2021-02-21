using System;
using System.Collections;
using System.Collections.Generic;

namespace ATSDLab1
{
    public class MyNode<T> where T: IComparable, IComparable<T>
    {
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }
        public MyNode(T data)
        {
            Data = data;
        }
    }
    public class MySortedLinkedList<T> : IEnumerable<T> where T : IComparable, IComparable<T>
    {
        private MyNode<T> first;
        private MyNode<T> last;
        private int count;
        public int Count {
            get { return count; }
            private set { count = value; }
        }

        public MySortedLinkedList() {
            count = 0;
        }
        public MySortedLinkedList(T[] elms)
        {
            foreach (T el in elms) {
                this.AddItem(el);
            }
            Count = elms.Length;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
        public void MakeEmpty()
        {
            first = null;
            last = null;
        }
        public bool Search(T item)
        {
            foreach (T el in this) {
                if (el.Equals(item)) {
                    return true;
                }
            }
            return false;
        }
        public void AddItem(T newItem)
        {
            MyNode<T> newNode = new MyNode<T>(newItem);
            if (first == null)
            {
                first = newNode;
                last = newNode;
            } else
            {
                MyNode<T> current = first;
                if (newItem.CompareTo(current.Data) <= 0)
                {
                    newNode.Next = first;
                    first = newNode;
                    Count++;
                    return;
                }
                while (current.Next != null)
                {
                    if (current.Data.CompareTo(newItem) <= 0 && current.Next.Data.CompareTo(newItem) == 1)
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                        Count++;
                        return;
                    }
                    current = current.Next;
                }
                if (last != null)
                {
                    last.Next = newNode;
                }
                last = newNode;
                Count++;
                return;
            }
        }
        public bool DeleteItem(T item)
        {
            MyNode<T> current = first;
            MyNode<T> previous = null;
            bool found = false;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        current = current.Next;
                        if (current.Next == null)
                            last = previous;
                        continue;
                    }
                    else
                    {
                        first = first.Next;

                        if (first == null)
                            last = null;
                    }
                    Count--;
                    found = true;
                }
                previous = current;
                current = current.Next;
            }
            return found;
        }
        public void Merge(MySortedLinkedList<T> newList)
        {
            MyNode<T> current = newList.first;
            while (current != null)
            {
                this.AddItem(current.Data);
                current = current.Next;
            }
            /*
            if (newList.IsEmpty())
            {
                return;
            }
            if (this.IsEmpty())
            {
                this.first = newList.first;
                this.last = newList.last;
                return;
            }
            MyNode<T> current = first;
            MyNode<T> newCurrent = newList.first;
            while (current != null)
            {
                if (newCurrent == null)
                {
                    break;
                }
                if (newCurrent.Data.CompareTo(current.Data) <= 0)
                {
                    MyNode<T> newNode = new MyNode<T>(newCurrent.Data);
                    newNode.Next = first;
                    first = newNode;
                    Count++;
                    newCurrent = newCurrent.Next;
                    continue;
                }
                if (current.Data.CompareTo(newCurrent.Data) < 0 && current.Next.Data.CompareTo(newCurrent.Data) >= 0)
                {
                    MyNode<T> newNode = new MyNode<T>(newCurrent.Data);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    newCurrent = newCurrent.Next;
                    Count++;
                    continue;
                }
                if (current.Data.CompareTo(newCurrent.Data) < 0)
                {
                    MyNode<T> newNode = new MyNode<T>(newCurrent.Data);
                    current.Next = newNode;
                    current = newNode;
                    last = current;
                    newCurrent = newCurrent.Next;
                }
            }
            */
        }
        public void PrintList()
        {
            foreach (T item in this)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.Write("\n");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            MyNode<T> current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
