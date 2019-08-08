using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc2.Introduction.Controllers
{
    public class FilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}