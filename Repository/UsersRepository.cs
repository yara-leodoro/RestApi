using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RESTApi.Data.VO;
using RESTApi.Model;
using RESTApi.Model.Context;
using RESTApi.Repository.Generic;

namespace RESTApi.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MySQLContext _context;

        public UsersRepository(MySQLContext context)
        {
            _context = context;
        }

        public Users validateCredentials(UsersVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }


        public Users RefreshUserInfo(Users users)
        {

            if(!_context.Users.Any(u => u.Id.Equals(users.Id))) return null;


            var result = _context.Users.SingleOrDefault(t => t.Id.Equals(users.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(users);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashesBytes = algorithm.ComputeHash(inputBytes);
            
            return BitConverter.ToString(hashesBytes);
        }
    }
}