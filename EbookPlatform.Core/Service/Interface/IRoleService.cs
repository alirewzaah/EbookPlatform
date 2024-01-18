using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.Service.Interface
{
    public interface IRoleService
    {
        public bool CheckPermission(int userid, int permissionid);
    }
}
