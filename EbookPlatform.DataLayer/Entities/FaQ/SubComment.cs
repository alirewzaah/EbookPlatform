using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform
{
    public class SubComment
    {
        [Key]
        public int subCommentID{ get; set; }
        public bool isActive { get; set; }
        public DateTime timeCreated { get; set; }
        [MaxLength(500)]
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string subCommentBody { get; set; }

        //relations
        public int userID{ get; set; }
        public int commentID{ get; set; }
        public virtual User user{ get; set; }
        public virtual Comment comment { get; set; }
        public SubComment()
        {
            
        }



    }
}
