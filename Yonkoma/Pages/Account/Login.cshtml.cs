using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Yonkoma.Models;


namespace Yonkoma.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Users Users { get; set; }

        public string Msg;
        public LoginModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            Users = new Users();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            var acc = Login(Users.Email, Users.Password);
            if (acc == null)    
            {
                Msg = "Invalid";
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("Email", acc.Email);
                return RedirectToPage("/Index");
            }

        }

        private Users Login(string email, string password)
        {
            var account = _context.Account.SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));

            if (account != null)
            {
                
                  return account;
                
            }
            return null;
        }
    }
}
