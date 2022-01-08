using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public DetailsModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        public programareCategory programareCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            programareCategory = await _context.programareCategory
                .Include(p => p.Category)
                .Include(p => p.programare).FirstOrDefaultAsync(m => m.ID == id);

            if (programareCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
