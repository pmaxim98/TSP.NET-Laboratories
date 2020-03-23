using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1TSPN
{
    public class Subscriber
    {
        public Publisher Publisher { get; private set; }

        public Subscriber(Publisher publisher)
        {
            Publisher = publisher;
        }
    }

    public class Publisher
    {
        public event EventHandler<string> DataPublisher;

        private void OnDataPublisher(string args)
        {
            DataPublisher?.Invoke(this, args);
        }

        public void PublishData(string data)
        {
            OnDataPublisher(data);
        }
    }

    public class Client
    {
        void publisherEventHandler_1(object sender, string e)
        {
            Console.WriteLine("Event handler 1: " + e);
        }

        void publisherEventHandler_2(object sender, string e)
        {
            Console.WriteLine("Event handler 2: " + e);
        }

        public Client()
        {
            Publisher pub;
            Subscriber sub1;
            Subscriber sub2;

            pub = new Publisher();

            sub1 = new Subscriber(pub);
            sub1.Publisher.DataPublisher += publisherEventHandler_1;

            sub2 = new Subscriber(pub);
            sub2.Publisher.DataPublisher += publisherEventHandler_2;

            pub.PublishData("Hello world");
        }
    }

    class Program
    {
        public static void Prime_1(object n)
        {
            int number = (int) n;

            for (int i = number - 1; i >= 2; --i)
            {
                bool isPrime = true;

                for (int d = 2; d * d <= i; ++d)
                {
                    if (i % d == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(2);
        }

        public static void Prime_2(object n)
        {
            int number = (int) n;
            int lastPrime = 2;

            for (int i = 3; i < number; ++i)
            {
                bool isPrime = true;

                for (int d = 2; d * d <= i; ++d)
                {
                    if (i % d == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    lastPrime = i;
            }

            Console.WriteLine(lastPrime);
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Prime_1));
            Thread t2 = new Thread(new ParameterizedThreadStart(Prime_2));

            Console.WriteLine("Start");

            t1.Start(2_000_000);
            t2.Start(2_000_000);

            t1.Join();
            t2.Join();

            Console.WriteLine("Finish");
        }
    }
}
