using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
    public class TeaShopVM
    {
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImageFile { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
