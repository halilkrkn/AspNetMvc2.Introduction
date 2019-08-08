using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetMvc2.Introduction.Pages.Customer
{
    public class IndexModel : PageModel
    {
        //CodeBehind Kısmı
        public string Message { get; set; }
        public void OnGet()
        {
            Message += "date is " + DateTime.Now.ToString();
        }
    }
}