using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Entities;
using AspNetMvc2.Introduction.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc2.Introduction.Controllers
{
    public class SessionDemoController : Controller
    {
        public String Index()
        {
            //Sessiona oluşturuldu ve değer atandı. set ile
            HttpContext.Session.SetInt32("age", 24);
            HttpContext.Session.SetString("Name", "Halil");
            HttpContext.Session.SetObject("student", new Student { Email = "Halilkrkn@gmail.com", FirstName = "Halil" });
            return "Session created";
        }

        public string GetSession(){

            // Bu Method ile sayfaya gösterdik. get ile

            return String.Format("Hello {0}, you are {1}. Student is {2}", HttpContext.Session.GetString("Name"),
                HttpContext.Session.GetInt32("age") ,
                HttpContext.Session.GetObject<Student>("student"));
        }
    }
}