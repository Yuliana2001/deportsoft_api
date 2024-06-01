using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using deportsoft_api.Models;
using deportsoft_api.Services;

namespace deportsoft_api.Pages
{
    public class DeleteDeportistModel : PageModel
    {
        private readonly deportsoft_api.Services.deportsoft_apiContext _context;

        public DeleteDeportistModel(deportsoft_api.Services.deportsoft_apiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Deportist Deportist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Deportsists == null)
            {
                return NotFound();
            }

            var deportist = await _context.Deportsists.FirstOrDefaultAsync(m => m.Id == id);

            if (deportist == null)
            {
                return NotFound();
            }
            else 
            {
                Deportist = deportist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Deportsists == null)
            {
                return NotFound();
            }
            var deportist = await _context.Deportsists.FindAsync(id);

            if (deportist != null)
            {
                Deportist = deportist;
                _context.Deportsists.Remove(Deportist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
