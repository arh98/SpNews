using SpNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpNews.Data.Ripositories
{
    public interface IUser
    {
        void AddUser(User user);
        bool IsExistUserEmail(string Email);
    }

    public class UserRepository : IUser
    {
        private SpNewsContext _context;

        public UserRepository(SpNewsContext context)
        {
            _context = context;
        }
        public bool IsExistUserEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
    }

}
