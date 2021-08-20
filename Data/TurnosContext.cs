using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Data
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options)
        {

        }
        
        public DbSet<Especialidad> Especialidad {get;set;}
    }
}