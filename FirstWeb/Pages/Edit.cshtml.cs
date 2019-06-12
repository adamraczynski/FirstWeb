using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDb _db;
        [BindProperty]
        public Customer Customer { get; set; }
        public EditModel(AppDb db) => _db = db;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _db.Customers.FindAsync(id);
            if (Customer == null) RedirectToPage("Customers");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _db.Customers.Attach(Customer).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer - {Customer.Id} not found!", e);
            }
            return RedirectToPage("Customers");
        }
    }
}