using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tea_Shop.Models;

namespace Tea_Shop.Interfaces
{
    public interface IShop
    {
        IEnumerable<TeaShop> GetDetails();
        int InsertDetails(TeaShop item);
        int UpdateDetails(TeaShop item);
        void DeleteDetails(int itemId);

    }
}