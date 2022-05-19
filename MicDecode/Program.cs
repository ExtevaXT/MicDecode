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
            string inputDir = @"C:\input\";
            string outputDir = @"C:\output\";

            Console.WriteLine("INPUT");
            inputDir = Console.ReadLine();
            Console.WriteLine("OUTPUT");
            outputDir = Console.ReadLine();
            if (inputDir == null || outputDir == null) return;
            var files = Directory.GetFiles(inputDir, "*.mic");
            foreach (string currentFile in files)
            {

                FileInfo f1 = new FileInfo(currentFile);

                string text = File.ReadAllText(f1.FullName, Encoding.GetEncoding(1252));
                text = text.Replace("MIC", "PNG");
                File.WriteAllText(string.Format("{0}{1}{2}", outputDir, f1.Name.Substring(0, f1.Name.Length - 4), ".png"), text, Encoding.GetEncoding(1252));

            }
        }
    }
}
