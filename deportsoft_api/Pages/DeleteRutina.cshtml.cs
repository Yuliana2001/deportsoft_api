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
    public class DeleteRutinaModel : PageModel
    {
        private readonly deportsoft_api.Services.deportsoft_apiContext _context;

        public DeleteRutinaModel(deportsoft_api.Services.deportsoft_apiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rutina Rutina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rutinas == null)
            {
                return NotFound();
            }

            var rutina = await _context.Rutinas.FirstOrDefaultAsync(m => m.Id == id);

            if (rutina == null)
            {
                return NotFound();
            }
            else 
            {
                Rutina = rutina;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rutinas == null)
            {
                return NotFound();
            }
            var rutina = await _context.Rutinas.FindAsync(id);

            if (rutina != null)
            {
                Rutina = rutina;
                _context.Rutinas.Remove(Rutina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
