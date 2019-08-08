using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc2.Introduction.Entities;
using AspNetMvc2.Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetMvc2.Introduction.Pages.Studentp
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }

        public void OnGet(string search)
        {
            Students = string.IsNullOrEmpty(search) ?
                _context.Students.ToList()
                : _context.Students.Where(s => s.FirstName.ToLower().Contains(search)).ToList();
                
        }



        //Ekleme işlemi dediğimiz zaman Post aklımıza gelmeli.,
        [BindProperty] // Ekrandaki Student ile başlayan Id, firstname vs. şeyleri Posta map edecektir.
        public Student Student { get; set; }

        public IActionResult OnPost()
        {
            _context.Students.Add(Student);
            _context.SaveChanges(); // Veri Tabanına ekleme durumu.

            return RedirectToPage("/Studentp/Index");

        }
    }
}