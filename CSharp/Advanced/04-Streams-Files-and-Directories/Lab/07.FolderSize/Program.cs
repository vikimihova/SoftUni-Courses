namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            long folderSize = CalculateFolderSize(folderPath, 0);

            File.Create(outputFilePath);

            using StreamWriter streamWriter = new StreamWriter(outputFilePath);

            streamWriter.Write($"{folderSize / 1024}kb");

        }

        public static long CalculateFolderSize(string folderPath, int level)
        {
            long folderSize = 0;

            string[] fileNames = Directory.GetFiles(folderPath);

            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                folderSize += fileInfo.Length;
            }

            string[] folderNames = Directory.GetDirectories(folderPath);

            foreach (string folderName in folderNames)
            {
                folderSize += CalculateFolderSize(folderName, level + 1);
            }

            return folderSize;
        }
    }
}
