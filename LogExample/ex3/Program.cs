
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
            Console.WriteLine("Hello world");

            for(int i = 0; i < 10; i++)
            {
                Execution();
            }

        }
        /// <summary>
        /// This function will start the code
        /// </summary>
        public static void Execution()
        {
            int zero = 0;

            try
            {
                int division = 1 / zero;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"The division is {ex.Message}");
                //throw ex; // Se lancio questa operazione si blocca tutto
            }

            return;
        }
    }
}