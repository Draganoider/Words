using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Words
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(1000);
            int i = 0;
            int l = 0;
            StreamReader input = new StreamReader("C:\\Users\\evgen\\Desktop\\Sample.txt");
            String[] contents = input.ReadToEnd()
                                                .ToLower()
                                                .Replace(",", "")
                                                .Replace("(", "")
                                                .Replace(")", "")
                                                .Replace(".", "")
                                                .Split(' ');
            input.Close();
            var dict = new Dictionary<string, int>();
            int value;
            foreach (var word in contents)
            {
                i++;
                dict[word] = dict.TryGetValue(word, out value) ? ++value : 1;
            }
            dict.Remove("");
            
			var ordered = from k in dict.Keys
						  orderby dict[k] descending
                              select k;
            
            using (StreamWriter output = new StreamWriter("C:\\Users\\evgen\\Desktop\\Result.txt"))
            {
                foreach (String k in ordered)
                {
                    output.WriteLine(String.Format("{0}: {1}", k, dict[k]));

                }
				foreach (string k in ordered)
				{
                    l++;

                }
                output.WriteLine("Всего уникальных слов : {0}", l);
                output.WriteLine("\nВсего слов : " + i);
                stopwatch.Stop();
                // Get the elapsed time as a TimeSpan value.

                TimeSpan ts = stopwatch.Elapsed;

                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                output.WriteLine("\nRunTime " + elapsedTime);
                output.Close();
                
                output.Close();
               
            }




        }
    }
}
