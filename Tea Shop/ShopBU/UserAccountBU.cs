﻿using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopBU
{
    public class UserAccountBU
    {
        public bool SignUp(UserAccountVM user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44393/api/UserAccount/");
                    var postTask = client.PostAsJsonAsync("CreateAccount", user);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SignIn(UserAccountVM user)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/UserAccount/");
                var responseTask = client.PostAsJsonAsync<UserAccountVM>("UserLogin", user);
                responseTask.Wait();

                var respResult = responseTask.Result;
                if (respResult.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool RestPassword(UserAccountVM _user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/UserAccount/");
                var responseTask = client.PutAsJsonAsync<UserAccountVM>("RestPassword",_user);
                responseTask.Wait();

                var respResult = responseTask.Result;
                if (respResult.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
