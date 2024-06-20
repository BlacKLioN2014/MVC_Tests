using Curso_Mvc.Data;
using Curso_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Curso_Mvc.Controllers
{
    public class InicioController : Controller
    {
        //private readonly ILogger<InicioController> _logger;


        private readonly ApplicationDbContext _dbContext;

        
        public InicioController(/*ILogger<InicioController> logger*/ApplicationDbContext dbContext)
        {
            //_logger = logger;
            _dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.contacto.ToListAsync());
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.FechaCreacion = DateTime.Now;

                _dbContext.contacto.Add(contacto);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(/*"Index"*/nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var contacto = _dbContext.contacto.Find(Id);
            if(contacto == null)
            {
                return NotFound();
            }
            

            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {

                _dbContext.contacto.Update(contacto);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(/*"Index"*/nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public IActionResult Detalle(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var contacto = _dbContext.contacto.Find(Id);
            if (contacto == null)
            {
                return NotFound();
            }


            return View(contacto);
        }


        [HttpGet]
        public IActionResult Borrar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var contacto = _dbContext.contacto.Find(Id);
            if (contacto == null)
            {
                return NotFound();
            }


            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? Id)
        {
            var contacto = await _dbContext.contacto.FindAsync(Id);
            if (contacto == null)
            {
                return View();
            }
            //Borrado
            _dbContext.contacto.Remove(contacto);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
