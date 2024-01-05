using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Favorite
    {
        [Key]
        public int favoriteID { get; set; }



        //realtions
        public int userID { get; set; }
        public int bookID{ get; set; }
        public virtual User User { get; set; }
        public Favorite()
        {
            
        }
    }
}
