using System;

namespace LinkedList
{
    public class ListIterator
    {
        private ListNode currentNode;

        public ListIterator(LinkedList list)
        {
            currentNode = list.Head;
        }

        public bool HasNext()
        {
            return currentNode != null;
        }

        public Object GetNext()
        {
            if (currentNode != null)
            {
                object o = currentNode.getData();
                currentNode = currentNode.Next;
                return o;
            }
            return null;
        }
    }
    
}
