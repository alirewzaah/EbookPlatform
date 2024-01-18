﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class RolePermission
    {
        [Key]
        public int rolePermissionID { get; set; }

     

        #region Relation

        public int roleID { get; set; }
        public virtual Role role { get; set; }


        public int permissionID { get; set; }
        public virtual Permission permission { get; set; }

        #endregion

        public RolePermission()
        {
                
        }


    }
}
