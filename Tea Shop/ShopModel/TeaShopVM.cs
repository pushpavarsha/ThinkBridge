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
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="Enter Alphabet only")]
        public string ItemName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,5}$",ErrorMessage ="Enter Number Only,Max length 5")]
        public int Price { get; set; }
        [Required(ErrorMessage ="Select Image")]
        public string ImageFile { get; set; }
        [Required(ErrorMessage ="Write something in Description")]
        public string Description { get; set; }
    }
}
