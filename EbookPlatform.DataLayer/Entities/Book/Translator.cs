using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform 
{
    public class Translator
    {
        [Key]
        public int translatorID { get; set; }
        [MaxLength(50)]
        [Display(Name = "نام مترجم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string translatorFullName{ get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        public string? description { get; set; }
        public bool isDeleted { get; set; }


        //relations
        public virtual List<Book> books { get; set; }   
        public Translator() { }
    }
}
