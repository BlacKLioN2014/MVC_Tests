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
