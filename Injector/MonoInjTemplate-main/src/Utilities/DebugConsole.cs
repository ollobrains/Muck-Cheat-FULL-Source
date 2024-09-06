using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MonoInjectionTemplate.Utilities
{
    public static class ConsoleBase
    {
        
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private static readonly StreamWriter StdOutWriter;
        private static StreamReader _stdInReader;

        static ConsoleBase()
        {
            AllocConsole();
            StdOutWriter = new StreamWriter(Console.OpenStandardOutput());
            _stdInReader = new StreamReader(Console.OpenStandardInput());
            StdOutWriter.AutoFlush = true;

            AttachConsole(-1);
            WriteLine("Console Initialized");
        }
        

        public static void Release()
        {
            FreeConsole();
        }

        public static string GetLine()
        {
            return _stdInReader.ReadLine();
        }
        public static void WriteLine(string line)
        {
            StdOutWriter.WriteLine(line);
            Console.WriteLine(line);
        }

        public static void Write(string msg)
        {
            StdOutWriter.Write(msg);
            Console.Write(msg);
        }

    }
}