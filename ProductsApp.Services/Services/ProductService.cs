using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;
using ProductsApp.Data.Models;
using ProductsApp.Services.Interfaces;

namespace ProductsApp.Services.Services
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _context;

        // Constructor que recibe el contexto inyectado
        public ProductService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize)
        {
            return await _context.Products
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(); // Método asíncrono para obtener datos de EF Core
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
                return null;

            existingProduct.Name = product.Name;
            existingProduct.Brand = product.Brand;
            existingProduct.Height = product.Height;
            existingProduct.Width = product.Width;
            existingProduct.Depth = product.Depth;
            existingProduct.Weight = product.Weight;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product); 
            await _context.SaveChangesAsync(); 
            return true; 
        }
    }
}