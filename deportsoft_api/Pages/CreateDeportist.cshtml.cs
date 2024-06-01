using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using deportsoft_api.Models;
using deportsoft_api.Services;

namespace deportsoft_api.Pages
{
    public class CreateDeportistModel : PageModel
    {
        private readonly deportsoft_api.Services.deportsoft_apiContext _context;

        public CreateDeportistModel(deportsoft_api.Services.deportsoft_apiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Deportist Deportist { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Deportsists == null || Deportist == null)
            {
                return Page();
            }

            _context.Deportsists.Add(Deportist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
