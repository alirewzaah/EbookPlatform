
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Book
    {
        [Key]
        public int bookID{ get; set; }

        public DateTime productCreated { get; set; }
        public DateTime productUpdated { get; set; }
        
        [MaxLength(300)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string bookTitle { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public float price { get; set; }
        [Display(Name = "درصد تخفیف")]
        public byte? discountPercentage { get; set; }
        [MaxLength(1000)]
        [Display(Name = "توضیحات کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string longDescription { get; set; }
        [Display(Name = "عکس")]
        public string? image { get; set; }
        [MaxLength(10)]
        public string? fileFormat { get; set; }
        [MaxLength(20)]
        public string? fileSize { get; set; }
        [Display(Name = "تعداد صفحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int pageCount { get; set; }
        [Display(Name = "تعداد فروش")]
        public int? salesCount{ get; set; }
        [MaxLength(150)]
        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? engTitle { get; set; }
        [Display(Name = "تاریخ انتشار")]
        public DateTime? releaseDate { get; set; }
        [Display(Name = "قیمت به دلار")]
        public float? priceInDollar { get; set; }
        [Display(Name = "قیمت نسخه چاپی")]
        public float? physicalVersionPrice { get; set; }
        [Display(Name = "فایل کتاب")]
        public string? bookEFile { get; set; }



        //relations
        public virtual List<Comment>? comments { get; set; }
        public int authorID { get; set; }
        public virtual Author? author { get; set; }
        public int translatorID{ get; set; }
        public virtual Translator?  translator { get; set; }
        public int publisherID { get; set; }
        public virtual Publisher? publisher { get; set; }
        public int languageID { get; set; }
        public virtual Language? language { get; set; }
        public List<Rating>? ratings { get; set; }
        //public virtual List<BookCategory>? bookCategories { get; set; }  
        public int categoryID { get; set; }
        public virtual Category? category { get; set; }



        public Book()
        {
            
        }

    }
}
