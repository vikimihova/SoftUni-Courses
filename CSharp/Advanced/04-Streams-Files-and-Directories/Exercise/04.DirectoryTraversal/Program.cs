namespace DirectoryTraversal
{
    using System;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new();

            string[] fileNames = Directory.GetFiles(inputFolderPath);

            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName); 

                if (!extensionsFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensionsFiles[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in extensionsFiles.OrderByDescending(x => x.Value.Count))
            {
                sb.AppendLine(kvp.Key);

                foreach (var fileInfo in kvp.Value.OrderBy(x => x.Length))
                {
                    sb.AppendLine($"--{fileInfo.Name} - {(double)(fileInfo.Length / 1024):F3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + reportFileName;  

            File.WriteAllText(filePath, textContent);
        }
    }
}
