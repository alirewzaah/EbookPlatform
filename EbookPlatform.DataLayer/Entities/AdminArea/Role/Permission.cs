using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Permission
    {
        [Key]
        public int permissionID { get; set; }

        public string permissionTitle { get; set; }

        #region Relation
        public virtual List<RolePermission> rolePermissions { get; set; }
        #endregion


        public Permission()
        {
                
        }
    }
}
