using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDb _db;
        [BindProperty]
        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public IndexModel(AppDb db) => _db = db;
        public async Task OnGetAsync() => Customers = await _db.Customers.AsNoTracking().ToListAsync();
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            _db.Customers.Attach(new Customer { Id = Id }).State = EntityState.Deleted;
            Message = "Deleted Successfull!";
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
