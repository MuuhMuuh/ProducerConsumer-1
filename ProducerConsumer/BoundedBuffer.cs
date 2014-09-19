using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue = new Queue<int>();
        private int _bufferSize;

        public BoundedBuffer(int bufferSize)
        {
            this._bufferSize = bufferSize;
        }

        public bool IsFull()
        {
            if (_queue.Count <= _bufferSize)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

        public void Put(int i)
        {
            _queue.Enqueue(i);
            Console.WriteLine("Buffer: Item {0} added", i);
        }

        public int Take()
        {
            while (_queue.Count == 0)
            {
                //Afvent på at køen bliver fyldt
            }
                int temp = _queue.Dequeue();
                return temp;
        }

    }
}
