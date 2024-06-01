using deportsoft_api.Models;
using deportsoft_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace deportsoft_api.Pages
{
    [Authorize(Roles = "admin")]
    public class UsuariosModel : PageModel
    {
        private readonly deportsoft_apiContext context;
        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
        public UsuariosModel(deportsoft_apiContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            ApplicationUsers = context.ApplicationUsers.OrderByDescending(p => p.Id).ToList();

        }
    }
}
