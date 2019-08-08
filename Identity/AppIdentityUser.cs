using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc2.Introduction.Identity
{
    //temel datayı barındırır.. Başka özelikleri kendimiz ekleyebiliriz
    public class AppIdentityUser:IdentityUser
    {
        public int Age { get; set; }
    }
}
