using deportsoft_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace deportsoft_api.Pages
{
    public class DeleteUserModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly deportsoft_apiContext context;
        public DeleteUserModel(IWebHostEnvironment environment, deportsoft_apiContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(string? id)
        {
            if (id == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }
            var usuario = context.ApplicationUsers.Find(id);
            if (usuario == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }

            context.ApplicationUsers.Remove(usuario);
            context.SaveChanges();
            Response.Redirect("/Usuarios");
        }
    }
}
