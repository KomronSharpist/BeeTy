using BeeTy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeeTy.Data.DbContexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "Server=localhost; Database=BeeTy; User Id=postgres; password=komronbek26";
        optionsBuilder.UseNpgsql(path);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>().Ignore(x => x.Company);


        modelBuilder.Entity<Plan>()
        .Property(p => p.UserId)
        .IsRequired();

        modelBuilder.Entity<Plan>()
        .Property(p => p.WorkerId)
        .IsRequired();


        modelBuilder.Entity<Order>()
       .Property(p => p.UserId)
       .IsRequired();

        modelBuilder.Entity<Order>()
        .Property(p => p.WorkerId)
        .IsRequired();
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Worker> Workers { get; set; }
    public virtual DbSet<Plan> Plans { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

}
