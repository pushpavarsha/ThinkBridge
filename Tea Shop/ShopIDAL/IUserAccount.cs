using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIDAL
{
    public interface IUserAccount
    {
         bool UserValidation(UserAccountVM user);
         bool SignUp(UserAccountVM user);
         bool RestPassword(UserAccountVM user);     
    }
}
