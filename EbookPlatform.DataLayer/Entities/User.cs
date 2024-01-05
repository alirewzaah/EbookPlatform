
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
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string firstName { get; set; }
        [MaxLength(150)]
        [Display(Name = " نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string lastName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime birthDate { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Ssn { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int phoneNumber { get; set; }
        [MaxLength(200)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string email { get; set; }
        [MaxLength(50)]
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string password { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool Sex { get; set; }
        public bool isActive{ get; set; }
        public bool isDeleted { get; set; }






        //relations
        public virtual List<Comment>? comments { get; set; }
        public virtual List<SubComment>? subComments { get; set; }
        public virtual List<Rating> ratings { get; set; }
        public virtual List<Favorite> favorites { get; set; }
       // public virtual List<UserRole> userRoles { get; set; }
       // public int libraryID { get; set; }
        public Library library { get; set; }
        public User()
        {
            
        }


    }
}
