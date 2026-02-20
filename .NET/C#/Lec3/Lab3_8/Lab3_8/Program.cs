using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_8
{
    internal class Program
    {
        public static void Word_Frequency_Counter(String sentence)
        {
            string[] words = sentence.Split(' ');
            int[] counters = new int[words.Length];

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                if (!wordCount.ContainsKey(currentWord))
                {
                    wordCount.Add(currentWord, 1);
                }
                else
                {
                    wordCount[currentWord] += 1;
                }
            }
            // Sorting the dictionary by value in descending order
            var sortedDict = wordCount.OrderByDescending(x => x.Value).ToList();
            foreach (var pair in sortedDict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
        static void Main(string[] args)
        {
            string sentence = "The cat and the dog and the bird";
            Word_Frequency_Counter(sentence);
        }
    }
}
