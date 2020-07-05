using ShopData;
using ShopIBL;
using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;



namespace ShopBL
{
    public class TeaShopRepo : ITeaShop
    {
        ThinkBridgeEntities db = new ThinkBridgeEntities();

        public void DeleteDetails(int itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeaShopVM> GetDetails()
        {  
              var item = db.TeaShops.Select(x => new TeaShopVM
                                        { 
                                            ItemId=x.ItemId,
                                            ItemName=x.ItemName,
                                            Price=x.Price,
                                            ImageFile=x.ImageFile,
                                            Description=x.Description
                                        });
                return item.ToList();
  
        }


        public TeaShopVM GetDetailsById(int itemId)
        {
            throw new NotImplementedException();
        }

        public void InsertDetails(TeaShopVM item)
        {
            throw new NotImplementedException();
        }

        public void UpdateDetails(TeaShopVM item)
        {
            throw new NotImplementedException();
        }
    }
}