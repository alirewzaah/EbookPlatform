using EbookPlatform.Core.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class UserService : IUserService
    {
        private MyEbookPlatformContext _context;
        public UserService(MyEbookPlatformContext context)
        {
                _context = context;
        }


        public int AddUser(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return user.userID;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                user.isDeleted = true;
                _context.users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DoesExist(string email, int id)
        {
            return _context.users.Any(u => u.email == email && u.userID != id);

        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public User Finduser(int userid, string Code)
        {
            return _context.users.Where(u => u.userID == userid && u.ActiveCode == Code).FirstOrDefault();
        }


        public User FindUserbuyeEmail(string Email)
        {
            return _context.users.Where(u => u.email == Email).FirstOrDefault();
        }

        public User LoginUser(string email, string Password)
        {
            return _context.users.Where(u => u.password == Password && u.email == email).SingleOrDefault();
        }


    }
}
