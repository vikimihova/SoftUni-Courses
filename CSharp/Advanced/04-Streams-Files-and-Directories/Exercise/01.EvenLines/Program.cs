namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder(); 

            using StreamReader stream = new StreamReader(inputFilePath);
            
            string line = string.Empty;

            int lineCount = 0;

            while (line != null)
            {
                line = stream.ReadLine();

                if (lineCount % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);

                    sb.AppendLine(reversedWords);
                }

                lineCount++;
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (var symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReverseWords(string words)
        {
            string[] reversedWords = words
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Reverse()
                                    .ToArray();

            return string.Join(" ", reversedWords);
        }
    }
}
