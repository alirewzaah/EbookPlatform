using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class UserRole
    {
        [Key]
        public int userRoleID { get; set; }


        #region Relation

        public int userID { get; set; }
        public virtual User user { get; set; }

        public int roleID { get; set; }
        public virtual Role role { get; set; }
        #endregion

        public UserRole()
        {
                
        }
    }
}
