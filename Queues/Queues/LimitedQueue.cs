using System;
using System.Collections.Generic;

namespace Queues
{
    internal class LimitedQueue<T>
    {
        private Queue<T> _queue;
        public LimitedQueue(int size)
        {
            _queue = new Queue<T>(size);
        }   
        
        internal void Enque(Object member)
        {       
                try
                {
                    Program.Pool.WaitOne();
                        _queue.Enqueue((T)member);
                    Console.WriteLine($@"Enque Thread {member} releases the semaphore.");               
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Source);
                }                             
        }

        internal void Deque(object member)
        {  
                    try
                    {
                        Console.WriteLine($@"Deque Thread {_queue.Dequeue()} releases the semaphore.");
                        Program.Pool.Release();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }     
        }
    }

