using HastaneGD1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneGD1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Poliklinik> polikliniks { get; set; }
        public DbSet<Randevu> randevus { get; set; }

        public DbSet<AnaBilimDali> anaBilimDali { get; set; }



    }
}