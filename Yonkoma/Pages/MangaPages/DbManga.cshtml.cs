using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Yonkoma.Models;

namespace Yonkoma.Pages.MangaPages
{
    public class DbMangaModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Manga> MangaPages { get; set; }
        public DbMangaModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            MangaPages = _context.MangaPages.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.MangaPages.FindAsync(id);

            if (product != null)
            {
                _context.MangaPages.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
