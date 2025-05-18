using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Entities.Models;
namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Company>? Companies { get; set; }
    }
}
