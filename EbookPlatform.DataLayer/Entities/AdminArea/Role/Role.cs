using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Role
    {
        [Key]
        public int roleID { get; set; }

        public string roleTitle { get; set; }


        #region Relation
        public virtual List<RolePermission> rolePermissions { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        #endregion

        public Role() 
        {
                
        }
    }
}
