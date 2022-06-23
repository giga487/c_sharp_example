
using System;
using System.Diagnostics;

namespace main
{
    static class Program
    {
        public static readonly int MAX_CYCLE_TO_PRINT = 5000;

        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
            Program.Execution();
        }
        /// <summary>
        /// This function will start the code
        /// </summary>
        public static void Execution()
        {
            Console.WriteLine("Hello world, fuck you");

            Trace.Listeners.Add(new TextWriterTraceListener(File.Create(Path.Combine(Environment.CurrentDirectory, "log.txt"))));
            Trace.Listeners.Add(new ConsoleTraceListener());

            Trace.AutoFlush = true;

            Stopwatch t = new Stopwatch();

            t.Start();

            Task _task = new Task( () => WriteInfo());
            _task.Start();

            TimeSpan ts = TimeSpan.FromMilliseconds(1500);

            if(!_task.Wait(ts))
                Trace.Write("The timeout interval elapsed.");

            t.Stop();

            Trace.Write($"Execution time {t.ElapsedMilliseconds}");


            return;
        }


        public static int WriteInfo()
        {
            int i = 0;
            for (i = 0; i < MAX_CYCLE_TO_PRINT; i++)
            {
                Trace.WriteLine("Andate tutti a fanculo");
            }

            return i;
        }
    }
}