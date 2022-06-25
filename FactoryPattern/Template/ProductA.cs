
namespace DesignPatterns.FactoryPattern.Template
{
    public class ProductA : IProduct
    {
        private const string _productName = "Product A";

        public string ProductName {
            get {
                return _productName;   
            }
        }
        public void ExecuteProductFunction()
        {
            Console.WriteLine(string.Format("Executing {0} Function", ProductName));
        }
    }
}