using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Shelf
    {
        [Key]
        public int shelfID { get; set; }
        [MaxLength(50)]
        [Display(Name = "عنوان قفسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string shelfTitle { get; set; }
        

        //relations
        public int libraryID { get; set; }
        public List<Book> books { get; set; }

    }
}
