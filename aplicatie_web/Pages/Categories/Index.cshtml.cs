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
    public class IndexModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public IndexModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        public IList<programareCategory> programareCategory { get;set; }

        public async Task OnGetAsync()
        {
            programareCategory = await _context.programareCategory
                .Include(p => p.Category)
                .Include(p => p.programare).ToListAsync();
        }
    }
}
