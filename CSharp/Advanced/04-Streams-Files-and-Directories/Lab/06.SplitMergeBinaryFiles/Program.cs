namespace SplitMergeBinaryFile
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.PortableExecutable;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream readerSource = new FileStream(sourceFilePath, FileMode.Open);

            byte[] buffer = new byte[1024];

            File.Create(partOneFilePath);
            File.Create(partTwoFilePath);

            using FileStream writerPartOne = new FileStream(partOneFilePath, FileMode.Create);
            using FileStream writerPartTwo = new FileStream(partTwoFilePath, FileMode.Create);            

            FileInfo fileInfo = new FileInfo(sourceFilePath);

            if (fileInfo.Length % 2 == 0)
            {
                for (int i = 0; i < fileInfo.Length / 2; i++)
                {
                    int size = readerSource.Read(buffer, 0, buffer.Length);
                    
                    while (size != 0)
                    {
                        writerPartOne.Write(buffer, 0, size);
                    }
                }

                for (int i = (int)fileInfo.Length / 2 + 1; i < fileInfo.Length; i++)
                {
                    int size = readerSource.Read(buffer, 0, buffer.Length);

                    while (size != 0)
                    {
                        writerPartTwo.Write(buffer, 0, size);
                    }
                }
            }
            else
            {
                for (int i = 0; i < fileInfo.Length / 2 + 1; i++)
                {
                    int size = readerSource.Read(buffer, 0, buffer.Length);

                    while (size != 0)
                    {
                        writerPartOne.Write(buffer, 0, size);
                    }
                }
            }

            for (int i = (int)fileInfo.Length / 2 + 2; i < fileInfo.Length; i++)
            {
                int size = readerSource.Read(buffer, 0, buffer.Length);

                while (size != 0)
                {
                    writerPartTwo.Write(buffer, 0, size);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            File.Create(joinedFilePath);

            FileInfo partOne = new FileInfo(partOneFilePath);
            FileInfo partTwo = new FileInfo(partTwoFilePath);

            using FileStream readerPartOne = new FileStream(partOneFilePath, FileMode.Open);
            using FileStream readerPartTwo = new FileStream(partTwoFilePath, FileMode.Open);

            using FileStream writerJoinedFile = new FileStream(joinedFilePath, FileMode.Create);

            byte[] buffer = new byte[1024];

            for (int i = 0; i < partOne.Length; i++)
            {
                int size = readerPartOne.Read(buffer, 0, buffer.Length);

                while (size != 0)
                {
                    writerJoinedFile.Write(buffer, 0, size);
                }
            }

            for (int i = 0; i < partTwo.Length; i++)
            {
                int size = readerPartTwo.Read(buffer, 0, buffer.Length);

                while (size != 0)
                {
                    writerJoinedFile.Write(buffer, 0, size);
                }
            }
        }
    }
}