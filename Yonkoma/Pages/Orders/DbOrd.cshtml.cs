using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Yonkoma.Models;

namespace Yonkoma.Pages.Orders
{
    public class DbOrdModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<OrderBy> Orders { get; set; }
        public DbOrdModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Orders = _context.Orders.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Orders.FindAsync(id);

            if (product != null)
            {
                _context.Orders.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
