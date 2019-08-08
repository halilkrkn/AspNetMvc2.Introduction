using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc2.Introduction.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        //Aksiyonun Önünde Çalışacak Kod Bloğu
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int i = 10;
        }

        //Aksiyonun Sonunda Çalışacak Kod Bloğu
        public void OnActionExecuted(ActionExecutedContext context)
        {
            int i = 20;
        }

    }
}
