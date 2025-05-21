using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class FileLogger : ILogger
    {
        private readonly IFileWriter _fileWriter;

        public FileLogger(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Log(string message)
        {
            Write(ConsoleColor.Green, message);
        }

        public void Error(string message)
        {
            Write(ConsoleColor.Red, message);
        }

        public void Warn(string message)
        {
            Write(ConsoleColor.Yellow, message);
        }

        private void Write(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            _fileWriter.WriteLine(message);
        }
    }

}
