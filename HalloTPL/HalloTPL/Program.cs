using System;
using System.Threading;
using System.Threading.Tasks;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle, Zähle, Zähle);
        //Parallel.For(0, 1000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

        Task t1 = new Task(() =>
        {
            Console.WriteLine("T1 gestartet");
            Thread.Sleep(1000);
            Console.WriteLine("T1 fertig");
        });


        Task<long> t2 = new Task<long>(() =>
        {
            Console.WriteLine("T2 gestartet");
            Thread.Sleep(2000);
            throw new OutOfMemoryException();
            Console.WriteLine("T2 fertig");

            return 9823479834798;
        });

        t2.ContinueWith(t => { Console.WriteLine("T2 Continue"); });//immer
        t2.ContinueWith(t => { Console.WriteLine($"T2 OK -> {t.Result}"); },TaskContinuationOptions.OnlyOnRanToCompletion);//nur OK
        t2.ContinueWith(t => { Console.WriteLine($"T2 ERROR {t.Exception.InnerException.Message}"); }, TaskContinuationOptions.OnlyOnFaulted);//nur ERROR

        t1.Start();
        t2.Start();

        //Console.WriteLine(t2.Result);

        Console.WriteLine("Ende");
        Console.ReadLine();
    }

    static void Zähle()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
        }
    }
}