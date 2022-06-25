using System.Data;

namespace DesignPatterns.FactoryPattern.Example
{
    public class FileReaderFactory : IFileReaderFactory
    {
        public IFileReader<T> GetFileReader<T>(string fileName)
        {

            switch (fileName) 
            {
                case "csv":
                    return new CsvReader() as IFileReader<T>;
                case "txt":
                    return new TextReader() as IFileReader<T>;

                default:
                    throw new ArgumentException("File Type not supported");
            }
        }
    }
}