using System;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Extensions.Configuration;


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

            Console.WriteLine("Hello world");
            ApplicationConfigurator();


        }
        /// <summary>
        /// This function will start the code
        /// </summary>
        public static void Execution()
        {
            //Console.WriteLine("Hello world, fuck you");

            return;
        }


        public static void ApplicationConfigurator()
        {
            ConfigurationBuilder configurationBuilder = new();//questo posso farlo perchè è scontata la classe, mai usato prima.
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot config = configurationBuilder.Build();
            TraceSwitch ts = new(displayName: "PacketSwitch", description: "This switch is set by JSON");

            
            var sectValue = config.GetSection("PacketSwitch");
            var level = sectValue.GetSection("Level");

            sectValue.Bind(ts);            
            Trace.WriteLineIf(ts.TraceError, "Trace Error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace Warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace Information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace Verbose");
        }
    }
}