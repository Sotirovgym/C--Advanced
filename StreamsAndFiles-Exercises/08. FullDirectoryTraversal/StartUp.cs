namespace _08._FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var path = Console.ReadLine();

            var folders = Directory.GetDirectories(path).ToList();
            var files = Directory.GetFiles(path).ToList();
            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < folders.Count; i++)
            {
                files.AddRange(Directory.GetFiles(folders[i]));
                folders.AddRange(Directory.GetDirectories(folders[i]));
            }

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                if (!dictionary.ContainsKey(fileInfo.Extension))
                {
                    dictionary[fileInfo.Extension] = new Dictionary<string, double>();
                }

                if (!dictionary[fileInfo.Extension].ContainsKey(fileInfo.Name))
                {
                    dictionary[fileInfo.Extension][fileInfo.Name] = fileInfo.Length;
                }
            }

            dictionary = dictionary
            .OrderByDescending(f => f.Value.Count)
            .ThenBy(f => f.Key)
            .ToDictionary(x => x.Key, x => x.Value);

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using (var writer = new StreamWriter($@"{desktopPath}\\report.txt"))
            {
                foreach (var dictionaryData in dictionary)
                {
                    var extensionName = dictionaryData.Key;
                    var filesData = dictionaryData.Value;

                    writer.WriteLine(extensionName);

                    foreach (var file in filesData.OrderBy(f => f.Value))
                    {
                        var fileName = file.Key;
                        var fileSize = file.Value;
                        
                        writer.WriteLine($"--{fileName} - {fileSize}kb");
                    }
                }
            }
        }
    }
}
