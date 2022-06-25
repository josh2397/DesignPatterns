
namespace DesignPatterns.FactoryPattern.Template
{
    public interface ICreator
    {
        IProduct CreateProduct(string productType);
    }
}