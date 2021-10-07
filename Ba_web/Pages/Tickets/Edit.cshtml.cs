using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ba_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ba_web.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Tickets_ba Ticket { get; set; }
        public async Task OnGet(int id)
        {
            Ticket = await _db.tickets.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TicketFromDb = await _db.tickets.FindAsync(Ticket.ID);
                TicketFromDb.Name = Ticket.Name;
                TicketFromDb.AddedAt = Ticket.AddedAt;
                TicketFromDb.Type = Ticket.Type;

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
