using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Ecomerce.CORE.Core.DTOs
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
    }

    public class FavoriteDetaiDTO
    {
        public int Id { get; set; }

        public UserFavoriteDTO User { get; set; }

        public ProductFavoriteDTO Product { get; set; }
    }
    public class FavoriteCreateDTO
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }

    }

}
