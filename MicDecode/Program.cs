using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirDefault = @"C:\input\";
            string outputDirDefault = @"C:\output\";

            Console.WriteLine("INPUT");
            string inputDir = Console.ReadLine();
            Console.WriteLine("OUTPUT");
            string outputDir = Console.ReadLine();
            if (inputDir == null || inputDir == "") inputDir = inputDirDefault;
            if (outputDir == null || outputDir == "") outputDir = outputDirDefault;


            //var files = Directory.GetFiles(inputDir, "*.mic");
            //foreach (string currentFile in files)
            //{

            //    FileInfo f1 = new FileInfo(currentFile);

            //    string text = File.ReadAllText(f1.FullName, Encoding.GetEncoding(1252));
            //    text = text.Replace("MIC", "PNG");
            //    File.WriteAllText(string.Format("{0}{1}{2}", outputDir, f1.Name.Substring(0, f1.Name.Length - 4), ".png"), text, Encoding.GetEncoding(1252));

            //}

            var inputDirPaths = Directory.GetDirectories(inputDir, "*", SearchOption.AllDirectories);

            foreach (string inputDirPath in inputDirPaths)
            {
                var files = Directory.GetFiles(inputDirPath, "*.mic");
                var outputDirPath = outputDir + Path.GetFileName(inputDirPath)+"\\";
                Directory.CreateDirectory(outputDirPath);
                foreach (string currentFile in files)
                {

                    FileInfo f1 = new FileInfo(currentFile);

                    string text = File.ReadAllText(f1.FullName, Encoding.GetEncoding(1252));
                    text = text.Replace("MIC", "PNG");
                    File.WriteAllText(string.Format("{0}{1}{2}", outputDirPath, f1.Name.Substring(0, f1.Name.Length - 4), ".png"), text, Encoding.GetEncoding(1252));

                }
            }
        }

    }
}
