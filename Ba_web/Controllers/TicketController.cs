using Ba_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ba_web.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TicketController(ApplicationDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _db.tickets.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketFromDb = await _db.tickets.FirstOrDefaultAsync(u => u.ID == id);
            if (ticketFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
             _db.tickets.Remove(ticketFromDb);
           await _db.SaveChangesAsync();
            return Json(new { success=true,message="Delete Successful"});
        }
    }
}
