using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ba_web.Pages
{
    public class _LoginPartialModel : PageModel
    {
        //[Authorize]
        //public IActionResult Dashboard()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await SignInManager.SignOutAsync();
        //    return RedirectToAction("login", "account");
        //}
    }
}
