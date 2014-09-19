using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            BoundedBuffer buffer = new BoundedBuffer(10000);

            Producer prod = new Producer(buffer, 21000000);
            Consumer cons = new Consumer(buffer, 21000000);


            //Brug Parallel.Invoke til at køre dem
           Parallel.Invoke(
                () => prod.Run(), 
                () => cons.Run()
                );
           Console.ReadLine();
        }
    }
}
