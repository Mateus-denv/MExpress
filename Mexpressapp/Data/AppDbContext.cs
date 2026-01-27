using Mexpressapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Mexpressapp.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
