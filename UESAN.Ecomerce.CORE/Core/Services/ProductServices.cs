using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Entities;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.CORE.Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetProducts();
            var list = new List<ProductListDTO>();

            foreach (var p in products)
            {
                list.Add(new ProductListDTO
                {
                    Id = p.Id,
                    Description = p.Description,
                    Price = (decimal)p.Price,
                    Category = p.Category == null ? null : new CategoriListDTO { Id = p.Category.Id, Description = p.Category.Description }
                });
            }

            return list;
        }

        public async Task<ProductDTO?> GetProductById(int id)
        {
            var p = await _productRepository.GetProductById(id);
            if (p == null) return null;

            return new ProductDTO
            {
                Id = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Stock = (int)p.Stock,
                Price = (decimal)p.Price,
                Discount = p.Discount,
                CategoryId = (int)p.CategoryId,
                IsActive = (bool)p.IsActive,
                Category = p.Category == null ? null : new CategoriListDTO { Id = p.Category.Id, Description = p.Category.Description }
            };
        }

        public async Task<int> CreateProduct(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock,
                Price = dto.Price,
                Discount = dto.Discount,
                CategoryId = dto.CategoryId,
                IsActive = dto.IsActive
            };

            return await _productRepository.InsertProduct(product);
        }

        public async Task<bool> UpdateProduct(ProductDTO dto)
        {
            var existing = await _productRepository.GetProductById(dto.Id);
            if (existing == null) return false;

            existing.Description = dto.Description;
            existing.ImageUrl = dto.ImageUrl;
            existing.Stock = dto.Stock;
            existing.Price = dto.Price;
            existing.Discount = dto.Discount;
            existing.CategoryId = dto.CategoryId;
            existing.IsActive = dto.IsActive;

            await _productRepository.UpdateProduct(existing);
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var existing = await _productRepository.GetProductById(id);
            if (existing == null) return false;

            await _productRepository.DeleteProduct(id);
            return true;
        }
    }
}
