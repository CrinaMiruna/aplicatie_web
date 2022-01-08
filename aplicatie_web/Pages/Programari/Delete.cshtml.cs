using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Programari
{
    public class DeleteModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public DeleteModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public programare programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            programare = await _context.programare.FirstOrDefaultAsync(m => m.ID == id);

            if (programare == null)
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

            programare = await _context.programare.FindAsync(id);

            if (programare != null)
            {
                _context.programare.Remove(programare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
