using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Entities;
using AspNetMvc2.Introduction.Models;
using AspNetMvc2.Introduction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvc2.Introduction.Controllers
{
    public class EmployeeController : Controller
    {
        private ICalculator _calculator; //bu Depencing İnjection ın İmplementasyodur.
       // private ICalculator _calculator2; services.AddTransient<> için kullanım şekli
        public EmployeeController(ICalculator calculator /*, ICalculator calculator2 */)
        {
            _calculator = calculator;
           // _calculator2 = calculator2;

        }
        public IActionResult Add()
        {   
             
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text="Ankara", Value="6"},
                    new SelectListItem{Text="İstanbul", Value="2"}
                    
                }
            };
            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }

        public string Calculate()
        {
          // _calculator2.Calculate(1000); services.AddTransient<> için bu şekilde kullanabiliriz
            return _calculator.Calculate(100).ToString();
        }
    }
}