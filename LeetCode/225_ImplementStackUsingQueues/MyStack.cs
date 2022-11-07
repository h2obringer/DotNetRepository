using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _225_ImplementStackUsingQueues
{
    public class MyStack
    {
        private Queue<int> _queue;
        private Queue<int> _queue2;
        private int current; //1 or 2

        public MyStack()
        {
            _queue = new Queue<int>();
            _queue2 = new Queue<int>();
            current = 1;
        }

        public void Push(int x)
        {
            if (current == 1)
            {
                _queue.Enqueue(x);
            }
            else
            {
                _queue2.Enqueue(x);
            }
        }

        public int Pop()
        {
            int result;

            //grab the last item off of the current queue...
            if (current == 1)
            {
                while(_queue.Count > 1)
                {
                    _queue2.Enqueue(_queue.Dequeue());
                }
                result = _queue.Dequeue();
                current = 2;
            }
            else
            {
                while (_queue2.Count > 1)
                {
                    _queue.Enqueue(_queue2.Dequeue());
                }
                result = _queue2.Dequeue();
                current = 1;
            }

            return result;
        }

        public int Top()
        {
            int result;

            //grab the last item off of the current queue...
            if (current == 1)
            {
                while (_queue.Count > 1)
                {
                    _queue2.Enqueue(_queue.Dequeue());
                }
                result = _queue.Dequeue();
                _queue2.Enqueue(result);
                current = 2;
            }
            else
            {
                while (_queue2.Count > 1)
                {
                    _queue.Enqueue(_queue2.Dequeue());
                }
                result = _queue2.Dequeue();
                _queue.Enqueue(result);
                current = 1;
            }

            return result;
        }

        public bool Empty()
        {
            return _queue.Count == 0 && _queue2.Count == 0;
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}
