using System;
using System.Text.RegularExpressions;

namespace DesignPatterns.FactoryPattern.Example
{
    public class TextReader : IFileReader<string>
    {
        public TextReader()
        {
            FieldNames = new List<string>();
        }
        public List<string> FieldNames { get; set; }

        public string ReadFile(string name)
        {
            return "";
        }
    }

}

