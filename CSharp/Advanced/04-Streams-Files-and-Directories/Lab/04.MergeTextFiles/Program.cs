namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Text;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader reader1 = new StreamReader(firstInputFilePath);
            StreamReader reader2 = new StreamReader(secondInputFilePath);

            StringBuilder sb = new StringBuilder();

            string lineText1 = string.Empty;
            string lineText2 = string.Empty;

            while (lineText1 != null || lineText2 != null)
            {
                lineText1 = reader1.ReadLine();
                lineText2 = reader2.ReadLine();

                sb.AppendLine(lineText1);
                sb.AppendLine(lineText2);
            }

            File.Create(outputFilePath);

            StreamWriter writer = new StreamWriter(outputFilePath);

            writer.Write(sb.ToString());    
        }
    }
}
