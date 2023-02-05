using System;
using System.Threading;
using System.Threading.Tasks;
using SuperVet.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperVet.Data
{
	public class VetContext : DbContext
	{
        public VetContext(DbContextOptions<VetContext> options) : base(options)
        { }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=root;Database=SuperVet;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

