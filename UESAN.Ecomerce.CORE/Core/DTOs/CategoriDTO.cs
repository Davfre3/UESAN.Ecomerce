using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Ecomerce.CORE.Core.DTOs
{
    public class CategoriDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

    }
    public class CategoriCreateDTO
    {
        public string? Description { get; set; }
    }
    public class CategoriListDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }

}
