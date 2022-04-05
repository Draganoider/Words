using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Words
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = File.ReadAllText(@"C:\\Users\\evgen\\Desktop\\Sample.txt");
			char[] arr;
			int checker = 0;

			int quantity = text.Length;
			arr = text.ToCharArray(0, quantity);

			for (int i = 0; i < quantity; i++)
			{
				if (arr[i] == ' ')
				{
					string word = text.Substring(checker, i);

					int wordLenght = word.Length;
					Regex r = new Regex(word);
					MatchCollection tx = r.Matches(text);
					if (tx.Count > 0)
					{
						foreach (Match m in tx)
							Console.WriteLine("Слово в тексте: " + m.Value);
					}
					checker += wordLenght + 1;
					word = "";
					Console.ReadKey();
				}
				
			}


		}
    }
}
