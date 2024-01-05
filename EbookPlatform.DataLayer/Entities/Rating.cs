using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Rating
    {
        [Key]
        public int ratingID { get; set; }
        public byte score { get; set; }



        //relations
        public int userID { get; set; }
        public int bookID { get; set; }
        public virtual User user { get; set; }
        public virtual Book book { get; set; }
        public Rating()
        {
            
        }

    }
}
