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
            BoundedBuffer buffer = new BoundedBuffer(4);

            Producer prod = new Producer(buffer, 15);
            Consumer cons = new Consumer(buffer);
            Consumer cons2 = new Consumer(buffer);


            //Brug Parallel.Invoke til at køre dem
           Parallel.Invoke(
                () => prod.Run(), 
                () => cons.Run(),
                () => cons2.Run()
                );
            Console.WriteLine("Done!");
           Console.ReadLine();
        }
    }
}
