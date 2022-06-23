
using System;
using System.Diagnostics;

namespace main
{


    static class Program
    {
        public static readonly int MAX_CYCLE_TO_PRINT = 5000;

        /// <summary>
        /// This test will study the task wait and other stuffs utils.
        /// The Trace loggin in file and the Debug Console is used for test the code
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
            //Console.WriteLine("Hello world, fuck you");

            Trace.Listeners.Add(new TextWriterTraceListener(File.Create(Path.Combine(Environment.CurrentDirectory, "log.txt"))));
#if DEBUG
            Trace.Listeners.Add(new ConsoleTraceListener());
#endif
            Trace.AutoFlush = true;

            Stopwatch t = new Stopwatch();

            t.Start();

            Task _task = new Task( () => WriteInfo());
            _task.Start();

            TimeSpan ts = TimeSpan.FromMilliseconds(500);

            if(!_task.Wait(ts))
            {
                Trace.Flush();
                Trace. WriteLine("The timeout interval elapsed.");
            }


            t.Stop();

            Trace.Flush();
            Trace.WriteLine($"Execution time {t.ElapsedMilliseconds}");


            return;
        }


        public static void WriteInfo()
        {

            for(int i = 0; i < MAX_CYCLE_TO_PRINT; i++)
            {
                Trace.WriteLine("Andate tutti a fanculo");
            }
        }
    }
}