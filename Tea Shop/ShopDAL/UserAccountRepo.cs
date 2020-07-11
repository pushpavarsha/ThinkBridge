using ShopData;
using ShopIDAL;
using ShopModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ShopDAL
{
    public class UserAccountRepo : IUserAccount
    {
        ThinkBridgeEntities db = new ThinkBridgeEntities();

        public bool SignUp(UserAccountVM user)
        {
            UserAccount _user = db.UserAccounts.Where(x => x.EmailId == user.EmailId).FirstOrDefault();
            if(_user==null)
            { 
            UserAccount newAccount = new UserAccount();
            newAccount.Username = user.Username;
            newAccount.EmailId = user.EmailId;
            newAccount.Password = encrypt(newAccount.Password);
            db.UserAccounts.Add(newAccount);
            db.SaveChanges();
            return true;
            
            }
            else
            {
                return false;
            }

        }

        public bool UserValidation(UserAccountVM user)
        {
            user.Password = encrypt(user.Password);
            bool isValid = db.UserAccounts.Any(x => x.EmailId == user.EmailId && x.Password == user.Password);
            if(isValid)
            {
                FormsAuthentication.SetAuthCookie(user.EmailId, false);
                return true;
            }

            return false;
        }
        public string encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public bool RestPassword(UserAccountVM user)
        {
            UserAccount _user = db.UserAccounts.Where(x => x.EmailId == user.EmailId).FirstOrDefault();
            if(_user!=null)
            {
                _user.Password = user.Password;
                return true;
            }
            return false;
        }
    }
}
