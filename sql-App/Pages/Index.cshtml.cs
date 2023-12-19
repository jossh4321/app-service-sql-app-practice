using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sql_App.Models;
using sql_App.Service;

namespace sql_App.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        public List<Product> productList;
        private IProductService productService;

        public IndexModel(IProductService service)
        {
            productService = service;
        }


        /*public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        public void OnGet()
        {
            //ProductService productService = new ProductService();
            productList = productService.getAllProducts();
        }
    }
}