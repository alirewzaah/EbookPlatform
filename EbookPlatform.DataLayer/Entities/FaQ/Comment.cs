using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }
        public DateTime timeCreated { get; set; }
        [MaxLength(500)]
        [Display(Name = "نقد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string commentBody { get; set; }
        public int likesCount { get; set; }
        public bool isActive { get; set; }



        //relations
        public int bookID { get; set; }
        public int userID { get; set; }
        public virtual User user { get; set; }
        public virtual List<SubComment> subComments { get; set; }
        public Comment()
        {
                
        }

    }
}
