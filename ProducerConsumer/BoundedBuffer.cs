﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            lock (_queue)
            {
                while (IsFull())
                {
                    //Afvent indtil der er plads
                    Monitor.Wait(_queue);
                }
                _queue.Enqueue(i);
                Console.WriteLine("Buffer: Item {0} added", i);
                Monitor.PulseAll(_queue);
            }
        }

        public int Take()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    //Afvent på at køen bliver fyldt
                    Monitor.Wait(_queue);
                }
                int temp = _queue.Dequeue();
                Console.WriteLine("Buffer: Item {0} removed", temp);
                Monitor.PulseAll(_queue);
                return temp;
                
            }
        }

    }
}
