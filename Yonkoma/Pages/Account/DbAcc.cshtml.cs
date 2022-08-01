using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yonkoma.Models;
using Microsoft.EntityFrameworkCore;

namespace Yonkoma.Pages.Account
{
    public class DbAccModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Users> Account { get; set; }
        public DbAccModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Account = _context.Account.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Account.FindAsync(id);

            if (product != null)
            {
                _context.Account.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
