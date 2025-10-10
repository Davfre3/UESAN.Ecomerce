using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.Entities;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.CORE.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Data.StoreDbContext _context;

        public ProductRepository(Data.StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product
                .Include(p => p.Category)
                .Where(p => p.IsActive == true)
                .ToListAsync();
        }

        public IEnumerable<Product> GetProductsAll()
        {
            return _context.Product
                .Include(p => p.Category)
                .ToList();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> InsertProduct(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _context.Product.FindAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Description = product.Description;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.IsActive = product.IsActive;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
