
namespace DesignPatterns.FactoryPattern.Template
{
    public class ProductB : IProduct
    {
        private const string _productName = "Product B";

        public string ProductName {
            get {
                return _productName;
            }
        }

        public void ExecuteProductFunction()
        {
            Console.WriteLine(string.Format("Executing {0} function", ProductName));
        }

    }
}