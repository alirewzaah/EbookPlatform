
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        [MaxLength(150)]
        [Display(Name = "نام")]
        public string? firstName { get; set; }
        [MaxLength(150)]
        [Display(Name = " نام خانوادگی")]
        public string? lastName { get; set; }
        [MaxLength(150)]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? birthDate { get; set; }

        [Display(Name = "کد ملی")]
        public int? Ssn { get; set; }

        [Display(Name = "شماره تلفن")]
        public int? phoneNumber { get; set; }
        [MaxLength(200)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string email { get; set; }
        [MaxLength(50)]
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string password { get; set; }

        [Display(Name = "جنسیت")]
        public bool? Sex { get; set; }
        public bool isActive{ get; set; }
        public bool isDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public string ActiveCode { get; set; }





        //relations
        public virtual List<Comment>? comments { get; set; }
        public virtual List<SubComment>? subComments { get; set; }
        public virtual List<Rating> ratings { get; set; }
        public virtual List<Favorite> favorites { get; set; }
        public virtual List<UserRole> userRoles { get; set; }
       // public int libraryID { get; set; }
        public Library library { get; set; }
        public User()
        {
            
        }


    }
}
