using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookPlatform.Core.ViewModels
{
    public class LoginViewmodel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل اجباری است")]
        public string email { get; set; }

        [Required(ErrorMessage = "وارد کردن پسورد اجباری است")]
        public string Password { get; set; }

        public bool Rememberme { get; set; }

    }
}
