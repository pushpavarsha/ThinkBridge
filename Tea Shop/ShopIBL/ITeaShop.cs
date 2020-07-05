using ShopData;
using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ShopIBL
{
    public interface ITeaShop
    {
        IEnumerable<TeaShopVM> GetDetails();
        TeaShopVM GetDetailsById(int itemId);
        void InsertDetails(TeaShopVM item);
        void UpdateDetails(TeaShopVM item);
        void DeleteDetails(int itemId);

    }
}