using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Library
    {
        [Key]
        public int libraryID { get; set; }


        //relation
        public int userID { get; set; }
        public virtual User user { get; set; }
        public virtual List<Shelf> Shelves { get; set; }
        public Library() { }
    }
}

