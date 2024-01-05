using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Author
    {
        [Key]
        public int authorID{ get; set; }
        [MaxLength(50)]
        [Display(Name="نام نویسنده")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string authorFullName{ get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        public bool isDeleted { get; set; }

        //relations
        public virtual List<Book> books { get; set; } 

    }
}
