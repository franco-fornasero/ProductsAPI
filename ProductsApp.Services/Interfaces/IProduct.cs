using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsApp.Data.Models;

namespace ProductsApp.Services.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize);
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
