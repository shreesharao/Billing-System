using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillingSystem.Entities;
using Utility.DatabaseHelper;
using Utility.PasswordManager;

namespace BillingSystem.DAL
{
   public class UserDL:BaseDL
    {
        #region Private variables
        bool isSuccess = false;
        int result = 0;
        DatabaseGateway _objDBGateway = null;
        private string _dbType = string.Empty;
        #endregion

        public UserDL()
        {
            _dbType = base.GetDatabaseTypeFromConfig();
            _objDBGateway = new DatabaseGateway(_dbType);
        }
        public bool Login(UserEntity entity)
        {
            _objDBGateway = new DatabaseGateway(_dbType);
            int result = 0;

            try
            {
                string query = "select count(*) from TB_Login where USERNAME='" + entity.UserName + "' and PASSWORD='" + EncryptPassword(entity.Password) + "'";

                result = _objDBGateway.ExecuteScalar<int>(query);
                if (result > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return isSuccess;
        }

        
        public bool CheckUserName(string username)
        {
            _objDBGateway = new DatabaseGateway(_dbType);
            int result = 0;

            try
            {
                string query = "select count(*) from TB_Login where USERNAME='" + username + "'";

                result = _objDBGateway.ExecuteScalar<int>(query);
                if (result > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return isSuccess;
        }
        public int Register(UserEntity entity)
        {
            _objDBGateway = new DatabaseGateway(_dbType);
            int result = 0;

            try
            {
                string query = "insert into TB_Login(USERNAME,PASSWORD) values('" + entity.UserName + "','" + entity.Password+ "')";

                result = _objDBGateway.ExecuteNonQuery(query);


            }
            catch (Exception ex)
            {


                throw;
            }
            return result;
        }

        private string EncryptPassword(string password)
        {
            var passWordHash = PasswordMgr.Encrypt(password);

            return passWordHash;
        }

        private string DecryptPassword(string passwordHash)
        {
            var password=PasswordMgr.Decrypt(passwordHash);

            return password;
        }
    }
}
