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
            BoundedBuffer buffer2 = new BoundedBuffer(4); //Brugt til MiddleMan

            Producer prod = new Producer(buffer, 15);
            //Consumer cons = new Consumer(buffer);
            //Consumer cons2 = new Consumer(buffer);
            MiddleMan mm = new MiddleMan(buffer, buffer2); //Tager fra buffer og indsætter i buffer2
            Consumer consMm = new Consumer(buffer2);

            //Brug Parallel.Invoke til at køre dem
           Parallel.Invoke(
                () => prod.Run(), 
                //() => cons.Run(),
                //() => cons2.Run()
                () => mm.Run(),
                () => consMm.Run()
                );
            Console.WriteLine("Done!");
           Console.ReadLine();
        }
    }
}
