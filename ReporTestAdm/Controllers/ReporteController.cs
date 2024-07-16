using Microsoft.AspNetCore.Mvc;
using ReporTestAdm.Models;
using Microsoft.EntityFrameworkCore;
using ReporTestAdm.ViewModels;

namespace ReporTestAdm.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ReportesContext _reportesContext;
        public ReporteController(ReportesContext reportesContext)
        {
            _reportesContext = reportesContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            try
            {
                var viewModel = new ReportesViewModel
                {
                    Reportes = await _reportesContext.Reportes.ToListAsync(),
                    Usuarios = await _reportesContext.Usuarios.ToListAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al obtener los reportes y usuarios: " + ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int folio, string estatus )
        {
            try
            {
                var reporte = await _reportesContext.Reportes.FirstOrDefaultAsync(r => r.Folio == folio);
                if (reporte == null)
                {
                    return NotFound();
                }
                Random random = new();
                reporte.Estatus = estatus;
                reporte.Fecha_autorizacion = DateTime.Now;
                reporte.Usuario_gestiona = "ADMINISTRADOR " + random.Next(1, 8);

                await _reportesContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Ocurió un error al enviar el reporte " + ex.ToString());
            }

            return RedirectToAction(nameof(List));

        }
    }
}
