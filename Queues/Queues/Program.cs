using System.Threading;

namespace Queues
{   
    class Program
    {
        public static Semaphore Pool;        
        static void Main()
        {
            var queue = new LimitedQueue<int>(3); 
            Pool = new Semaphore(3,3);
            for (var i = 1; i <= 10; i++)
            {
                var t1 = new Thread(queue.Enque);
                var t2 = new Thread(queue.Deque);
                t1.Start(i);
                t2.Start(i);
            }
        }
    }
}
