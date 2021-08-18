using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace BatchDeleteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]))
            {
                Console.WriteLine("filePath or fileExtension not empty");
                return;
            }

            var filePath = args[0];
            var fileExtension = args[1];

            var fileInfos = new DirectoryInfo(filePath).EnumerateFiles($"*.{fileExtension}", SearchOption.AllDirectories);

            foreach (FileInfo fi in fileInfos)
            {
                string fileFullName = $"{fi.DirectoryName}\\{fi.Name}";
                File.Delete(fileFullName);
                Console.WriteLine($"Delete File：{fileFullName}");
            }

            Console.WriteLine("Delete Success!!");
            Console.ReadLine();
        }
    }
}
