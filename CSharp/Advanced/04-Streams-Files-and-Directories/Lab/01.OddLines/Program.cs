namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {            
            using StreamReader reader = new StreamReader(inputFilePath);                
            
            File.Create(outputFilePath);

            using StreamWriter writer = new StreamWriter(outputFilePath);

            string line = string.Empty;

            int lineCount = 0;

            while (line != null)
            {
                line = reader.ReadLine();

                if (lineCount % 2 == 0)
                {
                    writer.WriteLine(line);
                }

                lineCount++;
            }
        }
    }
}
