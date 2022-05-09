using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;
        string hash = "";
        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }
        public void Add(Admin entity)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(entity.UserName);
            byte[] data2 = UTF8Encoding.UTF8.GetBytes(entity.Password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                byte[] keys2 = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    entity.UserName = Convert.ToBase64String(results, 0, results.Length);
                    byte[] results2 = transform.TransformFinalBlock(data2, 0, data2.Length);
                    entity.Password = Convert.ToBase64String(results2, 0, results2.Length);
                }
            }
            _loginDal.Add(entity);
        }
        public Admin DecryptToPassword(Admin admin)
        {

            Admin admin1 = new Admin();
            admin1.UserName = admin.UserName;
            admin1.Password = admin.Password;
            return admin1;
            //byte[] data = Convert.FromBase64String(admin.UserName);
            //byte[] data2 = Convert.FromBase64String(admin.Password);
            //using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            //{
            //    List<Admin> values = new List<Admin>();
            //    Admin value = new Admin();
            //    string userName, password;
            //    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            //    byte[] keys2 = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            //    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            //    {
            //        ICryptoTransform transform = tripDes.CreateDecryptor();
            //        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            //        userName = UTF8Encoding.UTF8.GetString(results);
            //        byte[] results2 = transform.TransformFinalBlock(data2, 0, data2.Length);
            //        password = UTF8Encoding.UTF8.GetString(results2);
            //        value.UserName = userName;
            //        value.Password = password;
            //        //values.Add(userName);
            //        //values.Add(password);
            //        return value;
            //    }

        }
        public void Delete(Admin entity)
        {
            _loginDal.Delete(entity);
        }

        public List<Admin> GetAll()
        {
            return _loginDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _loginDal.Get(x => x.Id == id);
        }

        public void Update(Admin entity)
        {
            _loginDal.Update(entity);
        }
    }

}

