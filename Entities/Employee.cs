using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc2.Introduction.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int  CityId { get; set; }

    }   
}
