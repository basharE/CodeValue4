using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SyncDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string path = @"C:\temp\data.txt";
                using (Mutex syncFileMutex = new Mutex(false, "bashar"))
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        syncFileMutex.WaitOne();
                        File.AppendAllText(path, Process.GetCurrentProcess().Id.ToString());                                                                                  
                        syncFileMutex.ReleaseMutex();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
