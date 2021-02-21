using System;

namespace ATSDLab1
{
    class Program
    {
        static void Main(string[] args)
        {

            //MySortedLinkedList<int> list1 = new MySortedLinkedList<int>(new int[] { 1, 10, 4, 5, 2, 6, 2, 2, 9, 0, 2});
            //MySortedLinkedList<int> list2 = new MySortedLinkedList<int>(new int[] { -1, -2, 4, 5, 2, 11, 12, 10 });
            //MySortedLinkedList<string> list1 = new MySortedLinkedList<string>(new string[] { "c", "b", "a", "e" });
            MySortedLinkedList<int> list1 = new MySortedLinkedList<int>(new int[] { 1, 10, 4 });
            MySortedLinkedList<int> list2 = new MySortedLinkedList<int>(new int[] { -1, -2, 4, 11, 12 });
            list1.PrintList();
            
            list1.DeleteItem(2);
            list1.PrintList();
            list1.Merge(list2);
            list1.PrintList();
            /*
            list1.AddItem(6);
            list1.PrintList();
            list1.MakeEmpty();
            list1.PrintList();
            list1.AddItem(6);
            list1.PrintList();
            */
        }   
    }
}
