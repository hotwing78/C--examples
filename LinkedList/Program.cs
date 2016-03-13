using System;

namespace LinkedList
{
    public class LinkedList
    {
        private ListNode head;

        internal ListNode Head
        {
            get { return head; }
            set { head = value; }
        }
        
        private ListNode tail;
        internal ListNode Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public void AddFirst(object o)
        {
            ListNode node = new ListNode();
            node.setData(o);
            node.Next = head;
            head = node;
            if (tail == null)
            {
                tail = node;
            }
        }

        public void AddLast(object o)
        {
            ListNode node = new ListNode();
            node.setData(o);
            if (tail != null)
            {
                tail.Next = node;
            }
            else // empty list, so set head as well
            {
                head = node;
            }
            tail = node;
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
            }

            if (head == null) // testing the new value of head
            {
                tail = null; // list is empty
            }
        }

        public void RemoveLast()
        {
            ListNode curr;
            if (head == null)
                return;
            // if there is a single entry, set head and tail to null
            if (tail == head)
            {
                head = null;
                tail = null;
                return;
            }

            // We have at least two entries, fix the tail
            curr = head;
            while (curr.Next != tail)
            {
                curr = curr.Next;
            }
            tail = curr;
            tail.Next = null;
        }

        public ListIterator getIterator()
        {
            return new ListIterator(this);
        }

        // FIXME
        public void Sort()
        {
            bool swap = true;
            ListNode lastSwap = tail;

            // empty or a single entry, just return
            if (head == null || head.Next == null)
            
                return;

            while (swap)
            {
                swap = false;
                ListNode loopEnd = lastSwap;
                for (ListNode curNode = head; curNode != loopEnd; curNode = curNode.Next )
                {
                    ListNode nextNode = curNode.Next;
                    // if we need to move things, swap the data
                    if (curNode.ToString().CompareTo(nextNode.ToString()) > 0)
                    {
                        Object tmp = nextNode.getData();
                        nextNode.setData(curNode.getData());
                        curNode.setData(tmp);
                        swap = true;
                        lastSwap = nextNode;
                    }
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string name;
            LinkedList list = new LinkedList();

            Console.Write("Enter name(quit to exit): ");
            name = Console.ReadLine();
            while (name != "quit")
            {
                list.AddLast(name);
                Console.Write("Name(quit to exit): ");
                name = Console.ReadLine();
            }

            ListIterator walker = list.getIterator();
            while (walker.HasNext())
            {
                string str = (string)walker.GetNext();
                Console.WriteLine("Name: {0}", str);
            }

            list.Sort();
            Console.WriteLine("\nSORTED:");

            walker = list.getIterator();
            while (walker.HasNext())
            {
                string str = (string)walker.GetNext();
                Console.WriteLine("Name: {0}", str);
            }
        }
    }
}
