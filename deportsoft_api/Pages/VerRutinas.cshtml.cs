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
    public class VerRutinasModel : PageModel
    {
        private readonly deportsoft_api.Services.deportsoft_apiContext _context;

        public VerRutinasModel(deportsoft_api.Services.deportsoft_apiContext context)
        {
            _context = context;
        }

        public IList<Rutina> Rutina { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rutinas != null)
            {
                Rutina = await _context.Rutinas.ToListAsync();
            }
        }
    }
}
