using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Turnos.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var especialidad = await _context.Especialidad.Where(x => x.IdEspecialidad == id).FirstOrDefaultAsync();
            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if(id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            
            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(especialidad);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(x => x.IdEspecialidad == id);
            if(especialidad != null)
            {
                return View(especialidad);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = _context.Especialidad.Find(id);

            if(especialidad != null)
            {
                this._context.Especialidad.Remove(especialidad);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}