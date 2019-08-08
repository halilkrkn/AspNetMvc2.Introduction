using System.Collections.Generic;
using AspNetMvc2.Introduction.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvc2.Introduction.Models
{
    public class EmployeeAddViewModel
    {
        public Employee Employee { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}