using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Duplicator
    {
        private BoundedBuffer _bufferIn;
        private BoundedBuffer _bufferOut1;
        private BoundedBuffer _bufferOut2;

        public Duplicator(BoundedBuffer bufferIn, BoundedBuffer bufferOut1, BoundedBuffer bufferOut2)
        {
            _bufferIn = bufferIn;
            _bufferOut1 = bufferOut1;
            _bufferOut2 = bufferOut2;
        }

        public void Run()
        {
            int temp;
            do
            {
                temp = _bufferIn.Take();
                _bufferOut1.Put(temp);
                _bufferOut2.Put(temp);
            } while (temp != -1);
        }
    }
}
