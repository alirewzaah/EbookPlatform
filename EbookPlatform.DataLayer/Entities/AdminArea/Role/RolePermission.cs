using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.DataLayer.Entities.AdminArea.Role
{
    public class RolePermission
    {
        [Key]
        public int rolePermissionID { get; set; }

        public int roleid { get; set; }

        public int permissionid { get; set; }


        #region Relation


        public virtual Role role { get; set; }


        public virtual Permission permission { get; set; }

        public RolePermission()
        {

        }
        #endregion


    }
}
