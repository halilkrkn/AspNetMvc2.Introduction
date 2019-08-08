using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc2.Introduction.Models.Security
{
    public class LoginViewModel
    {
        [Required] // ile Kullanıcı ile Şifrenin girilmesinin zorunlu olmasını sağladık
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
