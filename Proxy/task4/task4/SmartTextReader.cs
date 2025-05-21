using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextReader
    {
        protected readonly string FilePath;

        public SmartTextReader(string filePath)
        {
            FilePath = filePath;
        }

        public virtual char[][] ReadFile()
        {
            var lines = File.ReadAllLines(FilePath);
            var result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
    }
}
