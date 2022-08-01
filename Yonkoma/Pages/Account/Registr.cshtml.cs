using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yonkoma.Models;

namespace Yonkoma.Pages.Account
{
    public class RegistrModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Users Users { get; set; }
        public RegistrModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Account.Add(Users);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
