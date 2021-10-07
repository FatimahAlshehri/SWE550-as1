using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ba_web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ba_web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        
        public LoginModel(ApplicationDBContext db)
        {
            _db = db;

        }

        [BindProperty]
        public UserLoginDto user { get; set; }
    }
}
