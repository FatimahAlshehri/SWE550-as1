using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ba_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ba_web.Pages.Tickets
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Tickets_ba> tickets { get; set; }
        public async Task OnGet()
        {
            tickets = await _db.tickets.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ticket = await _db.tickets.FindAsync(id);
            if(ticket == null)
            {
                return NotFound();
            }
             _db.tickets.Remove(ticket);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
