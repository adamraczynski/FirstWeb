using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Core;
using FirstWeb.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDb _db;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public EditModel(AppDb db, IHtmlHelper htmlHelper)
        {
            _db = db;
            _htmlHelper = htmlHelper;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            States = _htmlHelper.GetEnumSelectList<CustomerState>();
            Customer = await _db.Customers.FindAsync(id);
            return Customer is null ? (IActionResult)RedirectToPage("Customers") : Page();
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