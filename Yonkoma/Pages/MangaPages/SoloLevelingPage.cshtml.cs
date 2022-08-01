using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yonkoma.Models;

namespace Yonkoma.Pages.MangaPages
{
    public class SoloLevelingPageModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Manga manga { get; set; }
        public SoloLevelingPageModel(ApplicationContext db)
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
                _context.MangaPages.Add(manga);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
