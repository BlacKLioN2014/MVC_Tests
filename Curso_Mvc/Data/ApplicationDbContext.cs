using Curso_Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_Mvc.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
            
        }

        //Agregar los modelos (cada modelo corresponde a una tabla en la DB
        public DbSet<Contacto> contacto {  get; set; }
        
    }
}
