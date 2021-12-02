using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\oldboyee\Desktop\Text1.txt";

            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            var stopWatch1 = Stopwatch.StartNew();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    var signs = sr.ReadToEnd();
                    foreach (var item in signs.Split(' ', '!', '\''))
                    {
                        list.Add(item);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Производительность вставки в List<T>: {stopWatch1.Elapsed.TotalMilliseconds} мс. ");

            Console.WriteLine();

            var stopWatch2 = Stopwatch.StartNew();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    var signs = sr.ReadToEnd();

                    foreach (var item in signs.Split(' ', '!', '\''))
                    {
                    linkedList.AddFirst(item);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           Console.WriteLine($"Производительность вставки в LinkedList<T>: {stopWatch2.Elapsed.TotalMilliseconds} мс.");

            Console.ReadLine();
        }

    }
}
