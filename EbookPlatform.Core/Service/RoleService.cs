using EbookPlatform.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service
{
    public class RoleService:IRoleService
    {
        private MyEbookPlatformContext _context;
        public RoleService(MyEbookPlatformContext context)
        {
            _context = context;
        }

        public bool CheckPermission(int userid, int permissionid)
        {
            var Rolid = _context.userRoles.Where(c => c.userID == userid)
                .Select(c => c.roleID).ToList();

            if (!Rolid.Any())
                return false;


            List<int> RolPermission = _context.rolePermissions
                .Where(p => p.permissionID == permissionid).Select(p => p.roleID).ToList();


            return RolPermission.Any(c => Rolid.Contains(c));

        }

    }
}
