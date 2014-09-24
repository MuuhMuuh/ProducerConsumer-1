using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        private BoundedBuffer _buffer;
        private int _production;
        public Producer(BoundedBuffer buffer, int produce)
        {
            _buffer = buffer;
            _production = produce;

        }

        public void Run()
        {
            //int i = 0;
            //while (i <= _production)
            //{
            //    if (_buffer.IsFull())
            //    {
            //        //vent til der er plads
            //    }
            //    else
            //    {
            //        _buffer.Put(i);
            //        //Console.WriteLine("Producer: Put {0}", i);
            //        i++;
            //    }

                for (int k = 0; k < _production; k++)
                {
                    _buffer.Put(k);
                }
                _buffer.Put(-1);
            }
        }
    }
