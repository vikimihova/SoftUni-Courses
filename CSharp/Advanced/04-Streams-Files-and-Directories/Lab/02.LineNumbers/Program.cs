namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);            

            File.Create(outputFilePath);

            using StreamWriter writer = new StreamWriter(outputFilePath);

            string line = string.Empty;

            int lineCount = 1;

            while (line != null)
            {
                line = reader.ReadLine();

                writer.WriteLine($"{lineCount}. {line}");

                lineCount++;
            }
        }
    }
}
