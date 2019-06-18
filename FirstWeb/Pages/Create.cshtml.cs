using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstWeb.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDb _db;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        public CreateModel(AppDb db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            _db.Customers.Add(Customer);
            Message = "Create successfull!";
            await _db.SaveChangesAsync();
            return RedirectToPage("/Customers");
        }
    }
}