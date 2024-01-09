using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Language
    {
        [Key]
        public int languageID{ get; set; }
        [MaxLength(50)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string languageTitle{ get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        public string? languageDescription { get; set; }
        public bool isDeleted { get; set; }


        //relations
        public virtual List<Book>? books { get; set; }   
        public Language() { }   
    }
}
