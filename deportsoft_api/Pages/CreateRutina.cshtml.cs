using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using deportsoft_api.Models;
using deportsoft_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace deportsoft_api.Pages
{
    public class CreateRutinaModel : PageModel
    {
        private readonly IWebHostEnvironment environment;

        private readonly deportsoft_api.Services.deportsoft_apiContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        [BindProperty]
        public RutinaDto RutinaDto { get; set; } = new RutinaDto();
        public CreateRutinaModel(deportsoft_apiContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public string errorMessage = "";
        public string successMessage = "";



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, llena todos los campos";
                return Page();
            }
            if (RutinaDto.ImageFile == null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "Se require que suba imagen");
            }

            //guardar la imagen
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(RutinaDto.ImageFile!.FileName);
            string imageFullPath = environment.WebRootPath + "/Rutina/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                RutinaDto.ImageFile.CopyTo(stream);
            }
            // Obtener el usuario actual
            var user = await userManager.GetUserAsync(User);

            Rutina rutina = new Rutina()
            {
                User = user,
                Nombre= RutinaDto.Nombre,
                Descripcion= RutinaDto.Descripcion,
                Duracion=RutinaDto.Duracion,
                Nivel= RutinaDto.Nivel,
                ImageFileName= newFileName,
                CreatedAt = DateTime.Now,


            };

            _context.Rutinas.Add(rutina);
            await _context.SaveChangesAsync();

            //Limpiar todo
            RutinaDto.Nombre = "";
            RutinaDto.Descripcion = "";
            RutinaDto.Duracion = 0;
            RutinaDto.Nivel = "";
            RutinaDto.ImageFile = null;
            ModelState.Clear();
            successMessage = "Ruy creado con exito";
            return RedirectToPage("/Index");
        }
    }
}
