using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Cart
    {
        [Key]
        public int cartID{ get; set; }
        public bool isPayed { get; set; }
        public DateTime dateCreated { get; set; }
        [Display(Name = "مبلغ قابل پرداخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public float finalPrice{ get; set; }
        [Display(Name = "شماره پیگیری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int refID { get; set; }




        //relations
        public int userID { get; set; }
        public virtual User user { get; set; }
        public virtual List<CartItem> cartItems { get; set; }
        public Cart() { }
    }
}
