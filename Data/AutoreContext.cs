using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using csharp_bibliotecaMvc.Models;
namespace csharp_bibliotecaMvc.Data
{
    public class AutoreContext : DbContext
    {
        public AutoreContext(DbContextOptions<AutoreContext> options) : base(options) { }
        public DbSet<Autore> ListaAutori { get; set; } = null!;

    }
}
