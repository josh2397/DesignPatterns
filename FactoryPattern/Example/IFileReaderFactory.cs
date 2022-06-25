
namespace DesignPatterns.FactoryPattern.Example
{
    public interface IFileReaderFactory
    {
        IFileReader<T> GetFileReader<T>(string fileName);
    }
}