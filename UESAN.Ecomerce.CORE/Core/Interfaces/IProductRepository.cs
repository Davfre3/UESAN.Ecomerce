using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.Entities;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();         
        IEnumerable<Product> GetProductsAll();             
        Task<Product?> GetProductById(int id);             
        Task<int> InsertProduct(Product product);          
        Task UpdateProduct(Product product);               
        Task DeleteProduct(int id);                        
    }
}
