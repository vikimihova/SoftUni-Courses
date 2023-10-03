namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> wantedBytes = new();

            using StreamReader bytesReader = new StreamReader(bytesFilePath);

            string line = string.Empty;

            while (line != null)
            {
                line = bytesReader.ReadLine();

                wantedBytes.Add(byte.Parse(line));
            }

            List<byte> occurrences = new();

            using FileStream binaryFile = new FileStream(binaryFilePath, FileMode.Open);

            byte[] buffer = new byte[binaryFile.Length];

            binaryFile.Read(buffer, 0, buffer.Length);

            for (int i = 0; i < buffer.Length; i++)
            {
                if (wantedBytes.Contains(buffer[i]))
                {
                    occurrences.Add(buffer[i]);
                }
            }

            using FileStream output = new FileStream(outputPath, FileMode.Create);

            output.Write(occurrences.ToArray(), 0, occurrences.Count);
        }
    }
}
