using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;

namespace ConsoleApp2
{
    class Program
    {
       
        static void When2()
        {
            if (EventLog.Exists("System"))
            {
                var log = new EventLog("System", Environment.MachineName, "EventLog");

                var entries = new EventLogEntry[log.Entries.Count];
                log.Entries.CopyTo(entries, 0);

                var startupTimes = entries.Where(x => x.InstanceId == 2147489653).Select(x => x.TimeGenerated);
                var shutdownTimes = entries.Where(x => x.InstanceId == 2147489654).Select(x => x.TimeGenerated);
             

                Console.WriteLine("Сколько последних включений/выключений вывести?");
                int ii;
                while (!Int32.TryParse( Console.ReadLine(),out ii))
                {
                    Console.WriteLine("Введите число");
                }
                startupTimes = startupTimes.Skip(startupTimes.Count() - ii);
                shutdownTimes = shutdownTimes.Skip(shutdownTimes.Count() - ii);
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (DateTime d in startupTimes)
                {
                    Console.WriteLine("Время включения: " + d);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (DateTime d in shutdownTimes)
                {
                    Console.WriteLine("Время выключения: " + d);
                }
                Console.ResetColor();

            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Paranoik tools Present:");
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();
            Prog:
            When2();
            goto Prog;
        }
    }
}
