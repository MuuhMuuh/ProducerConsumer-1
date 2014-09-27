using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class MiddleMan
    {
        private BoundedBuffer _bufferIn;
        private BoundedBuffer _bufferOut;

        public MiddleMan(BoundedBuffer bufferIn, BoundedBuffer bufferOut)
        {
            _bufferIn = bufferIn;
            _bufferOut = bufferOut;
        }

        public void Run()
        {
            int temp;
            do
            {
                temp = _bufferIn.Take();
                _bufferOut.Put(temp);
            } while (temp != -1);
        }
    }
}
