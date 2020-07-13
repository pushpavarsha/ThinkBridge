using ShopModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShopBU
{
    public class TeaShopBU
    {
        public IEnumerable<TeaShopVM> GetItemDetails()
        {
            IEnumerable<TeaShopVM> itemList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop/");
                var responseTask = client.GetAsync("SaleDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TeaShopVM>>();
                    readTask.Wait();

                    itemList = readTask.Result;
                }
                else
                {
                    itemList = Enumerable.Empty<TeaShopVM>();


                }
                return itemList;

            }
        }

        public bool InsertItem(TeaShopVM item)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop/");
                var postTask = client.PostAsJsonAsync<TeaShopVM>("AddItem",item);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
               
            }
            return false;
        }

        public  TeaShopVM GetItemById(int _item)
        {
            TeaShopVM itemList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop/");
                var responseTask = client.GetAsync("GetItemById/"+_item.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<TeaShopVM>();
                    readTask.Wait();

                    itemList = readTask.Result;
                }
                else
                {
                    itemList = null;


                }
                return itemList;

            }

        }

        public bool DeleteItem(int _item)
        {          
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop/");
                var responsetask = client.DeleteAsync("DeleteItem/" + _item.ToString());
                responsetask.Wait();
                var result = responsetask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }

        }

        public bool UpdateItem(TeaShopVM item)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress=new Uri("https://localhost:44393/api/TeaShop/");
                var responsetask = client.PutAsJsonAsync<TeaShopVM>("UpdateItem", item);
                responsetask.Wait();

                var result = responsetask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
