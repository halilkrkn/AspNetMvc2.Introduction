using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Entities;
using AspNetMvc2.Introduction.Filters;
using AspNetMvc2.Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc2.Introduction.Controllers
{
    public class HomeController : Controller
    {
        [HandleException(ViewName = "DivideByZeroError", ExceptionType = typeof(DivideByZeroException))]
        [HandleException(ViewName = "Error", ExceptionType = typeof(SecurityException))]
        public IActionResult Index()
        {
            //Hata Yakalama Yöntemi
           // throw new Exception("Some Exception occured");
           // throw new DivideByZeroException();
           // throw new SecurityException();
            return View();
        }

        public IActionResult Index2()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Halil", LastName="KARKIN", CityId=80 },
                new Employee{Id=1, FirstName="Hasan Göktuğ", LastName="KARKIN", CityId=01 },
                new Employee{Id=1, FirstName="Elif Gül", LastName="Çolak", CityId=20 },
                new Employee{Id=1, FirstName="Hatice Belkız", LastName="Çolak", CityId=20 },
            };

            List<string> cities = new List<string> { "İstanbul", "Ankara" };

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                cities = cities

            };
            return View(model);
        }


        //Status Result = Durum Kodu Sonucu HTTP kodlarını döndürür.
        //Api lerde olmazasa olmazdır.
        public IActionResult index3()
        {
            return StatusCode(200);
            // Ok(); bu kodun yerinde kullanılabilir.
        }
        public StatusCodeResult index4()
        { 
            return StatusCode(400);
            // BadRequest();
            // NotFound(); da kullanılabilir bu kodun yerine.
        }

        // RedirectResult = Yönlendirme Sonucu Aksiyon Sonucu.
        public RedirectResult index5()
        {
            return Redirect("/Home/İndex3"); 
            // İndex3 yönlendirme yapar.
        }

        // RedirectResult veya IActionResult da kullanılabilir.
        public IActionResult index6()
        {
            return RedirectToAction("İndex2"); // genel olarak bu kullanılıyor.
            //İstenilen Actiona gidiyor.
        }
        public IActionResult index7()
        {
            return RedirectToRoute("default");
            //Default route göre Çalıştırıyor.
        }

        //JsonResult = js için Json Formatında data döndürür.
        public JsonResult index8()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Halil", LastName="KARKIN", CityId=80 },
                new Employee{Id=1, FirstName="Hasan Göktuğ", LastName="KARKIN", CityId=01 },
                new Employee{Id=1, FirstName="Elif Gül", LastName="Çolak", CityId=20 },
                new Employee{Id=1, FirstName="Hatice Belkız", LastName="Çolak", CityId=20 },
            };

            return Json(employees);
        }


        public IActionResult RazorDemo()
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Halil", LastName="KARKIN", CityId=80 },
                new Employee{Id=1, FirstName="Hasan Göktuğ", LastName="KARKIN", CityId=01 },
                new Employee{Id=1, FirstName="Elif Gül", LastName="Çolak", CityId=20 },
                new Employee{Id=1, FirstName="Hatice Belkız", LastName="Çolak", CityId=20 },
            };

            List<string> cities = new List<string> { "İstanbul", "Ankara" };

            var model = new EmployeeListViewModel
            {
                Employees = employees,
                cities = cities

            };
            return View(model);

        }

        //ModelBinding = Controller action (aksiyonu) çalıştırıldığında ona parametre göndermektir
        public JsonResult index9(string key)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="Halil", LastName="KARKIN", CityId=80 },
                new Employee{Id=2, FirstName="Hasan Göktuğ", LastName="KARKIN", CityId=01 },
                new Employee{Id=3, FirstName="Elif Gül", LastName="Çolak", CityId=20 },
                new Employee{Id=4, FirstName="Hatice Belkız", LastName="Çolak", CityId=20 },
            };

            if (string.IsNullOrEmpty(key))
            {
                return Json(employees);
            }

            var result = employees.Where(e => e.FirstName.ToLower().Contains(key));

            return Json(result);
        }

        // ViewResault ile Form Datası oluşturup Model Binding Yaptık. Yukarıdaki index9 ile beraber filtreledik.
        public ViewResult EmployeeForm()
        {
            return View();
        }

       // RouteData ile de ModelBinding Yaptık.
        //public string RouteData(int id)
        //{
        //    return id.ToString();
        //}

    }
}