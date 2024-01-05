using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }
        [MaxLength(50)]
        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string title { get; set; }

        public bool isDeleted { get; set; }
        [MaxLength(250)]
        [Display(Name = "توضیحات")]
        public string? description { get; set; }



        //relations
        public virtual List<Book> books{ get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
        public Category() { }   


    }
}
