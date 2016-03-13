using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class SimpleQueue<T> : Queue<T>, IQueue<T>
    {
        public void Add(int priority, T element)
        {
            this.Enqueue(element);
        }

        public T Remove()
        {
            return this.Dequeue();
        }
    }
}
