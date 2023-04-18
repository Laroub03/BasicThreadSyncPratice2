using System;
using System.Threading;

class Program
{
    static int _number = 60;

    static object _lock = new object();


    static void Main()
    {
        Thread starsThread = new Thread(PrintStars);
        Thread hashesThread = new Thread(PrintHashes);
        starsThread.Start();
        hashesThread.Start();
        starsThread.Join();
        hashesThread.Join();
    }

    static void PrintStars()
    {
        {
            while (true)
            {
                Monitor.Enter(_lock);

                try
                {
                    for (int i = 0; i < _number; i++)
                    {
                    Console.Write("*");
                    }
                    Console.Write(_number);
                    Console.WriteLine();
                    _number += 60;
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);

                }
            }
        }
    }

    static void PrintHashes()
    {
        {
            while (true)
            {
                Monitor.Enter(_lock);

                try
                {
                    for (int i = 0; i < _number; i++)
                    {
                        Console.Write("#");
                    }
                    Console.Write(_number);
                    Console.WriteLine();
                    _number += 60;
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);

                }
            }
        }
    }
}

