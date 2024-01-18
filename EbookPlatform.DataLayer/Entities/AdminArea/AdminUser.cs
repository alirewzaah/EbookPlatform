
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class AdminUser
    {
        [Key]
        public int adminUserID { get; set; }
        [MaxLength(150)]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string adminUserName { get; set; }
        [MaxLength(150)]
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string adminUserPassword { get; set; }
        [MaxLength(50)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string adminUserEmail { get; set;}



        //realtions
       // public int roleID { get; set; }
       // public virtual Role role { get; set; }
        public AdminUser()
        {
                
        }

    }
}
