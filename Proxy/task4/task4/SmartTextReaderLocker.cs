using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task4
{
    public class SmartTextLocker : SmartTextReader
    {
        private readonly Regex _restrictionPattern;

        public SmartTextLocker(string filePath, string pattern)
            : base(filePath)
        {
            _restrictionPattern = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public override char[][] ReadFile()
        {
            if (_restrictionPattern.IsMatch(FilePath))
            {
                Console.WriteLine("Access denied!");
                return Array.Empty<char[]>();
            }

            return base.ReadFile();
        }
    }
}
