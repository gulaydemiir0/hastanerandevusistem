using Microsoft.EntityFrameworkCore;

namespace HastaneGD.Models
{
    public class HContext : DbContext
    {
        public HContext(DbContextOptions<HContext> options) : base(options)
        {
        }
        public DbSet<AnaBilimDali> anaBilimDalis { get; set; }
        public DbSet<Poliklinik> polikliniks { get; set; }
        public DbSet<Doktor> doktors { get; set; }
    }
}
