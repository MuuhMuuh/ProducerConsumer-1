using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            BoundedBuffer buffer = new BoundedBuffer(3);

            Producer prod = new Producer(buffer, 10);
            Consumer cons = new Consumer(buffer, 10);


            //Brug Parallel.Invoke til at køre dem
            Parallel.Invoke(
                () => prod.Run(), 
                () => cons.Run()
                );

            Console.ReadLine();
        }
    }
}
