using System.Data;

namespace DesignPatterns.FactoryPattern.Example
{
    public interface IFileReader<out T>
    {
        T ReadFile(string name);
    }
}