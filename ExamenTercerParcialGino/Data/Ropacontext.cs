using ExamenTercerParcialGino;
using ExamenTercerParcialGino.Models;
using Microsoft.EntityFrameworkCore;



namespace ExamenTercerParcialGino.Data
{
    public class Ropacontext:DbContext
    {
        public Ropacontext(DbContextOptions<Ropacontext>options):base(options) { }
        public DbSet<Ropa> Ropa  { get; set; } 
        
    }
}
