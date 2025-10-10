using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.DTOs;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductListDTO>> GetAllProducts();
        Task<ProductDTO?> GetProductById(int id);
        Task<int> CreateProduct(ProductCreateDTO dto);
        Task<bool> UpdateProduct(ProductDTO dto);
        Task<bool> DeleteProduct(int id);
    }
}
