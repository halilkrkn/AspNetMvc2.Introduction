using System.Collections.Generic;
using AspNetMvc2.Introduction.Entities;

namespace AspNetMvc2.Introduction.Models
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> cities { get; set; }
    }
}