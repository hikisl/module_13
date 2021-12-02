using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string path = @"C:\Users\oldboyee\Desktop\Text1.txt";

            using (var sr = new StreamReader(path))
            {
                var signs = sr.ReadToEnd().ToLower();

                string[] words = signs.Split(new char[] { ' ','_', '-', '.', '?', '!', ')', '(', ',', ':', '<', '>', '\n','\t' }, StringSplitOptions.RemoveEmptyEntries);
                var result = words.GroupBy(x => x)
                                  .Where(x => x.Count() > 1)
                                  .Select(x => new { Word = x.Key, Frequency = x.Count() });

                foreach (var item in result)
                {
                    if (item.Frequency > 1)
                    {
                        dictionary.Add(item.Word, item.Frequency);
                    }
                }
            }

            var frequentWords = dictionary.OrderByDescending(s => s.Value);

            int count = 0;

            Console.WriteLine("10 самых встречаемых слов в тексте: ");
            Console.WriteLine();

            foreach (var word in frequentWords)
            {
                Console.WriteLine("Слово: {0}\tКоличество повторов: {1}", word.Key, word.Value);
                count++;
                if (count == 10)
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
