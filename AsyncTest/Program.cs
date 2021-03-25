using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mainThreadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Main finish main thread: " + mainThreadId);
            await MethodNonWork();
            await MethodWork();
            //Work
            await Task.Factory.StartNew(() => MethodNonWork());
        }
        static async Task MethodNonWork()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Thread.Sleep(3000);
            Console.WriteLine("Method finished, id:" + threadId);
        }
        static async Task MethodWork()
        {
            await Task.Run(() =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(3000);
                Console.WriteLine("Method finished, id:" + threadId);
            });
        }
    }
}
