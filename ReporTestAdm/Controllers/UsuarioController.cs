using Microsoft.AspNetCore.Mvc;
using ReporTestAdm.Models;

namespace ReporTestAdm.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ReportesContext _context;

        public UsuarioController(ReportesContext context)
        {
            _context = context;
        }
        public IActionResult GetUsers()
        {
            var usuarios = _context.Usuarios.ToList();
            return Json(usuarios); // Devolver la lista de usuarios como JSON
            //return View();
        }
    }
}
