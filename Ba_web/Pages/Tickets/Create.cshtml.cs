using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ba_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ba_web.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
 
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        
        }

        [BindProperty]
        public Tickets_ba Ticket { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                await _db.tickets.AddAsync(Ticket);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
