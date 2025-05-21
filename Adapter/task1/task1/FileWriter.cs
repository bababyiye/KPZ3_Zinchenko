using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class FileWriter : IFileWriter
    {
        private readonly string _filename = Path.GetFullPath("file.txt");

        public void ClearFile()
        {
            File.WriteAllText(_filename, string.Empty);
            Console.WriteLine("Файл очищено!");
        }

        public void Write(string text)
        {
            using (var sw = new StreamWriter(_filename, true))
            {
                sw.Write(text + " ");
            }
        }

        public void WriteLine(string line)
        {
            using (var sw = new StreamWriter(_filename, true))
            {
                sw.WriteLine(line);
            }
        }
    }
}
