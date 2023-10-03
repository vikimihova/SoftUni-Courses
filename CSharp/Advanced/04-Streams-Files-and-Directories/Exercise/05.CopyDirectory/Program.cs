namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, recursive: true);
            }

            Directory.CreateDirectory(outputPath);

            string[] fileNames = Directory.GetFiles(inputPath);

            foreach (string fileName in fileNames)
            {
                string currentFileName = Path.GetFileName(fileName);
                string destination = Path.Combine(outputPath, currentFileName);

                File.Copy(fileName, destination);
            }
        }
    }
}
