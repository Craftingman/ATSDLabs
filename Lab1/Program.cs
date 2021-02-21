using System;

namespace ATSDLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //MySortedLinkedList<string> list1 = new MySortedLinkedList<string>(new string[] { "c", "b", "a", "e" });
            MySortedLinkedList<int> list1 = new MySortedLinkedList<int>(new int[] { 1, 10, 4 });
            MySortedLinkedList<int> list2 = new MySortedLinkedList<int>(new int[] { -1, -2, 4, 11, 12 });
            list1.PrintList();
            
            list1.DeleteItem(2);
            list1.PrintList();
            list1.Merge(list2);
            list1.PrintList();
        }   
    }
}
