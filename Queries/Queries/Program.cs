using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Queries
{
    static class Program
    {
        static void Main()
        {
            var ass = Assembly.Load(@"mscorlib");
            var firstQuere = from type in ass.GetTypes()
                where type.IsInterface && type.IsPublic
                orderby type.GetMethods().Count() ascending // should be ordered by name
                select new {InterfaceName = type.Name, NumberofMethods = type.GetMethods().Length};

            // ???
            foreach (var intrfac in firstQuere)
            {
                //Console.WriteLine(intrfac);
            }


            var procceses = Process.GetProcesses();

            var secondQuere = from proc in procceses
                // where is your checking for running proccesses
                where proc.Threads.Count < 5 
                orderby proc.Id
                select new {proc.ProcessName, proc.Id, proc.BasePriority /*,proc.StartTime*/};

            // ???
            foreach (var process in secondQuere)
            {
                //Console.WriteLine(process);
            }


            var thirQuere = from proc in secondQuere
                group proc by Process.GetProcessById(proc.Id).ProcessName
                into newProcess
                orderby newProcess.Key
                select newProcess.Key;

            // ???
            foreach (var process in thirQuere)
            {
                //Console.WriteLine(process);
            }

            // Should be:
            //var query3 = (from process in Process.GetProcesses()
            //              where CanAccess(process)
            //              select process.Threads.Count).Sum();
            var helpFourthQuere = from proc in procceses
                select new {proc.ProcessName, proc.Threads.Count};

            var fourthQuere = helpFourthQuere.Sum((x) => x.Count);

            Console.WriteLine($@"Number of Threads :  {fourthQuere}");
        }
        // Wrong answer
        public static void CopyTo(this object myObj, object obj)
        {
            var prop = from propertises in myObj.GetType().GetProperties()
                where propertises.CanRead
                select propertises;

            // ??????????
            from propertises in prop
            where propertises.CanWrite
            select new {prop = propertises.SetValue(obj, propertises.GetValue(myObj, null), null)};
        }
    }
}