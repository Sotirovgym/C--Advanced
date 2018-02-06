namespace _07._DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            //Try with input: Files
            var path = Console.ReadLine();

            var filesInfo = new DirectoryInfo(path);

            var groupedFiles = new Dictionary<string, HashSet<FileInfo>>();

            foreach (var file in filesInfo.GetFiles())
            {
                if (!groupedFiles.ContainsKey(file.Extension))
                {
                    groupedFiles[file.Extension] = new HashSet<FileInfo>();
                }

                groupedFiles[file.Extension].Add(file);
            }

            var sortedFiles = groupedFiles
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using (var writer = new StreamWriter($@"{desktopPath}\\report.txt"))
            {
                foreach (var groupFiles in sortedFiles)
                {
                    writer.WriteLine(groupFiles.Key);

                    var files = groupFiles.Value.OrderBy(f => f.Length);
                    foreach (var file in files)
                    {
                        writer.WriteLine($"--{file.Name} - {file.Length}kb");
                    }
                }
            }
        }
    }
}
