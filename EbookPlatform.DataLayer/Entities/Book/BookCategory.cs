using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class BookCategory
    {
        [Key]
        public int bookCategoryID { get; set; }

        public int bookID { get; set; }

        public int categoryID { get; set; }

     //relations
        [ForeignKey("categoryID")]
        public Category Category { get; set; }

        [ForeignKey("bookID")]
        public Book book { get; set; }
        public BookCategory()
        {
            
        }

    }
}
