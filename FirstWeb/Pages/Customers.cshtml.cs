using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstWeb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly AppDb _db;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public bool ShowMessage => !Message.IsNullOrEmpty();
        [BindProperty]
        public IEnumerable<Customer> Customers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public CustomersModel(AppDb db)
        {
            _db = db;
        }
        public async Task OnGetAsync() => Customers = await _db.GetCustomersByNameAsync(Name);
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            _db.Customers.Attach(new Customer { Id = Id }).State = EntityState.Deleted;
            Message = "Deleted Successfull!";
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}