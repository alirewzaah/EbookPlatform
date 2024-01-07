using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class SubCategory
    {
        [Key]
        public int subCategoryID { get; set; }
        [MaxLength(50)]
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string subCategoryTitle { get; set;}
        public bool isDeleted { get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        public string? description { get; set; }


        //relaitons
       // public  int categoryID { get; set; }
     //   public virtual Category category { get; set; }
     //   public virtual List<Book> books { get; set; }
        public SubCategory()
        {
            
        }
    }
}
