using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform 
{
    public class Publisher
    {
        [Key]
        public int publisherID { get; set; }
        [MaxLength(50)]
        [Display(Name = "نام ناشر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string publisherFullName { get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? description{ get; set; }
        public bool isDeleted { get; set; }


        //realtions
        public virtual List<Book>? books { get; set; }   
        public Publisher() { }  


    }
}
