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
            BoundedBuffer buffer = new BoundedBuffer(4); //Brugt til Termination
            BoundedBuffer buffer2 = new BoundedBuffer(4); //Brugt til MiddleMan + Duplicator
            BoundedBuffer buffer3 = new BoundedBuffer(4); //Brugt til Duplicator

            Producer prod = new Producer(buffer, 15);

            //Brugt til Termination
            //Consumer cons = new Consumer(buffer);
            //Consumer cons2 = new Consumer(buffer);

            //Brugt til MiddleMan
            MiddleMan mm = new MiddleMan(buffer, buffer2); //Tager fra buffer og indsætter i buffer2
            Consumer consMm = new Consumer(buffer2);

            //Brugt til Duplicator
            Duplicator duplicator = new Duplicator(buffer, buffer2, buffer3); //Tager fra buffer, og sætter værdien ind i både buffer2 & buffer3
            Consumer consDup = new Consumer(buffer2);
            Consumer consDup2 = new Consumer(buffer3);

            //Brug Parallel.Invoke til at køre dem
            Parallel.Invoke(
                 () => prod.Run(), //<- Brugt til Termination, MiddleMan, Duplicator

                //() => cons.Run(), //<- Brugt til Termination
                //() => cons2.Run() //<- Brugt til Termination

                 //() => mm.Run(), //<- Brugt til MiddleMan
                 //() => consMm.Run() //<- Brugt til MiddleMan

                 () => duplicator.Run(), //<- Brugt til Duplicator
                 () => consDup.Run(), //<- Brugt til Duplicator
                 () => consDup2.Run() //<- Brugt til Duplicator
                 );
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
