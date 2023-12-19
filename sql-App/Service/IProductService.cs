using sql_App.Models;

namespace sql_App.Service
{
    public interface IProductService
    {
        public List<Product> getAllProducts();
    }
}
