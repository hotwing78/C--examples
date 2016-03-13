using System;

namespace LinkedList
{
    public class ListNode
    {
        private Object data;

        private ListNode next = null;

        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public void setData(Object newData)
        {
            data = newData;
        }
        public Object getData()
        {
            return data;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}
