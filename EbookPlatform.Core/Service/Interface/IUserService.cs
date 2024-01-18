using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service.Interface
{
    public interface IUserService
    {
        int AddUser(User user);
        bool UpdateUser(User user); 
        bool DeleteUser(User user);
        bool DoesExist(string email, int id);
        public User Finduser(int userid, string Code);
        public User FindUserbuyeEmail(string Email);
        public User LoginUser(string email, string Password);

    }
}
