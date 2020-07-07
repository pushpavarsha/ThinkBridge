using ShopData;
using ShopIDAL;
using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;



namespace ShopDAL
{
    public class TeaShopRepo : ITeaShop
    {
        ThinkBridgeEntities db = new ThinkBridgeEntities();

        public void DeleteDetails(int _itemId)
        {
            TeaShop item = db.TeaShops.Where(x => x.ItemId == _itemId).FirstOrDefault();
            db.TeaShops.Remove(item);
            db.SaveChanges();
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

        
        public TeaShopVM GetDetailsById(int _itemId)
        {
            TeaShop item= db.TeaShops.Where(x => x.ItemId == _itemId).FirstOrDefault();
            TeaShopVM _item = new TeaShopVM();
            _item.ItemId = item.ItemId;
            _item.ItemName =item.ItemName;
            _item.Price =item.Price;
            _item.ImageFile =item.ImageFile;
            _item.Description = item.Description;

            return _item;        
        }

        public void InsertDetails(TeaShopVM item)
        {
            TeaShop _shopItem = new TeaShop();
            _shopItem.ItemName = item.ItemName;
            _shopItem.Price = item.Price;
            _shopItem.ImageFile = item.ImageFile;
            _shopItem.Description = item.Description;
            db.TeaShops.Add(_shopItem);
            db.SaveChanges();

        }

        public void UpdateDetails(TeaShopVM _item)
        {
            TeaShop item = new TeaShop();
            item.ItemName =_item.ItemName;
            item.Price =_item.Price;
            item.ImageFile =_item.ImageFile;
            item.Description =_item.Description;
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}