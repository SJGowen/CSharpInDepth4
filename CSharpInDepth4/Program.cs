using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpInDepth4
{
    class Program
    {
        private readonly List<string> list;

        public string Name { get; set; }

        public int Count => list.Count;

        static void Main(string[] args)
        {
            var book = (title: "Lost in the Snow", author: "Holly Webb");
            Console.WriteLine($"{book.title} by {book.author}.");
            try
            {
                var divisor = 0;
                var result = 23 / divisor;
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private static void LogException(Exception ex,
            [CallerMemberName] string callerMemberName = "",
            [CallerLineNumber] int callerLinesNumber = 0,
            [CallerFilePath] string callerFilePath = "")
        {
            Console.WriteLine(@$"Exception {ex.GetType()} ({ex.Message}), was thrown in {callerFilePath} method {callerMemberName} on line {callerLinesNumber}.");
        }

        public IEnumerator<string> Enumerator => list.GetEnumerator();

        static readonly string[] LowNames =
        {
            "NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL",
            "BS", "HT", "LF", "VT", "FF", "CR", "SO", "SI",
            "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB",
            "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US"
        };

        public static void DisplayString(string text)
        {
            Console.WriteLine($"String length: {text.Length}");
            foreach (char c in text)
            {
                if (c < 32)
                {
                    Console.WriteLine($"<{LowNames[c]}> U+{(int)c:x4}");
                }
                else if (c > 127)
                {
                    Console.WriteLine($"(Possibly non-printable) U+{(int)c:x4}");
                }
                else
                {
                    Console.WriteLine($"{c} U+{(int)c:x4}");
                }
            }
        }
    }
}
