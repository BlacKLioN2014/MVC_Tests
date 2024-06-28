using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        #region llamadas a la API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties:"Categoria") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoría" });
            }

            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.save();

            return Json(new { success = true, message = "Categoría borrada correctamente" });

        }

        #endregion
    }
}
