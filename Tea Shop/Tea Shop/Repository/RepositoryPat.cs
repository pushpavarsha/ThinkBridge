using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ModelBinding;
using Tea_Shop.Interfaces;
using Tea_Shop.Models;

namespace Tea_Shop.Repository
{
    public class RepositoryPat : IShop
    {
        public void DeleteDetails(int itemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeaShop> GetDetails()
        {
            IEnumerable<TeaShop> item = null;
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44370/api/");
                var response = client.GetAsync("TeaApi/SaleDetails");
                response.Wait();
                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readresponse=result.Content.ReadAsAsync<IEnumerable<TeaShop>>();
                    readresponse.Wait();
                    item = readresponse.Result;
                }
                else
                {
                    item = Enumerable.Empty<TeaShop>();
            
                }
                return item;
            }
           
        }

        public int InsertDetails(TeaShop item)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44370/api/");
                var postTask = client.PostAsJsonAsync<TeaShop>("TeaApi/AddItem/", item);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                    return 0;
            }
           
        }

        public int UpdateDetails(TeaShop item)
        {
            throw new NotImplementedException();
        }
    }
}