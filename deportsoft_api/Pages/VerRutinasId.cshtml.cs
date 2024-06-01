using deportsoft_api.Models;
using deportsoft_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;

namespace deportsoft_api.Pages
{
    public class VerRutinasIdModel : PageModel
    {
        public List<Rutina> Rutinas { get; set; } = new List<Rutina>();
        private readonly deportsoft_apiContext context;
        private readonly UserManager<ApplicationUser> userManager;
        [BindProperty]
        public RutinaDto RutinaDto { get; set; }=new RutinaDto();
        public VerRutinasIdModel(deportsoft_api.Services.deportsoft_apiContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var userId = user?.Id;
            if (userId != null)
            {
                Rutinas = context.Rutinas.Where(c => c.User.Id == userId)
                    .OrderByDescending(c => c.Id).ToList();
            }
        }
    }
}
