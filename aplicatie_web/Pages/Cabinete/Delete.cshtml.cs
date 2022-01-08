using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Cabinete
{
    public class DeleteModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public DeleteModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cabinet = await _context.Cabinet.FirstOrDefaultAsync(m => m.ID == id);

            if (Cabinet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cabinet = await _context.Cabinet.FindAsync(id);

            if (Cabinet != null)
            {
                _context.Cabinet.Remove(Cabinet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
