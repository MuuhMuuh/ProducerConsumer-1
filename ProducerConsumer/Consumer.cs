using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Consumer
    {
        private BoundedBuffer _buffer;
        private int _expectedAmount;

        public Consumer(BoundedBuffer buffer, int expectedAmount)
        {
            _buffer = buffer;
            _expectedAmount = expectedAmount;

        }

        public void Run()
        {
            for (int i = 0; i < _expectedAmount; i++)
            {
                _buffer.Take();
                Console.WriteLine("Consumer: Take {0}", i);
            }
        }
    }
    }

