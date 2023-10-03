namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader wordsReader = new StreamReader(wordsFilePath);

            string[] words = wordsReader.ReadToEnd()
                                        .ToLower()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 0);
                }
            }

            using StreamReader textReader = new StreamReader(textFilePath);

            StringBuilder text = new StringBuilder();

            text.Append(textReader.ReadToEnd().ToLower());

            StringBuilder cleanedText = new StringBuilder();

            foreach (char ch in text.ToString())
            {
                if (char.IsLetter(ch) || ch == ' ')
                {
                    cleanedText.Append(ch);
                }
            }

            string[] allWordsFromText = cleanedText.ToString()
                                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            File.Create(outputFilePath);

            using StreamWriter writer = new StreamWriter(outputFilePath);

            foreach (var kvp in wordCount)
            {
                string wantedWord = kvp.Key;
                int count = kvp.Value;

                foreach (string word in allWordsFromText)
                {
                    if (wantedWord == word)
                    {
                        count++;
                    }
                }
            }
            
            foreach (var kvp in wordCount)
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
