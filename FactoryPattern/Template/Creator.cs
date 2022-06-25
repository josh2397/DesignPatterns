
namespace DesignPatterns.FactoryPattern.Template
{
    public class Creator : ICreator
    {
        public IProduct CreateProduct(string productType = "A")
        {
            productType = productType.ToLower();
            switch (productType)
            {
                case "a":
                    return new ProductA();
                case "b":
                    return new ProductB();

                default:
                    throw new ArgumentException(string.Format("Could not create product of type {0} because it's doesn't exist", productType));
            }
        }
    }
}