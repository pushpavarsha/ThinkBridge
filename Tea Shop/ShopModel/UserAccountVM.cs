using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModel
{
   public class UserAccountVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter valid Email address")]
        [EmailAddress]
        public string EmailId { get; set; }
        // [Required]
        [RegularExpression("^[a-zA-Z_ ]+", ErrorMessage = "Enter Alphabet only")]
        public string Username { get; set; }
        [Required]
        //[RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\\]).{8,32}$",ErrorMessage ="")]
        public string Password { get; set; }      
       // [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
