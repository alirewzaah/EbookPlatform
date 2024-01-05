using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class CartItem
    {
        [Key]
        public int cartItemID { get; set; }
        public float price { get; set; }
        public DateTime dateAdded { get; set; }



        //relations
        public int bookID { get; set; }
        public virtual Book book { get; set; }
        public int cartID { get; set; }
        public virtual Cart cart { get; set; }
        public CartItem()
        {
            
        }
    }
}
