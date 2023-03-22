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

        modelBuilder.Entity<Order>()
                .Property<int>("BlogForeignKey");

        modelBuilder.Entity<Order>()
            .HasOne(p => p.User)
            .WithMany(b => b.Orders)
            .HasForeignKey("BlogForeignKey");

        modelBuilder.Entity<Plan>()
                .Property<int>("BlogForeignKey");

        modelBuilder.Entity<Plan>()
            .HasOne(p => p.User)
            .WithMany(b => b.Plans)
            .HasForeignKey("BlogForeignKey");


        modelBuilder.Entity<Order>()
                .Property<int>("BlogForeignKey");

        modelBuilder.Entity<Order>()
            .HasOne(p => p.Worker)
            .WithMany(b => b.Orders)
            .HasForeignKey("BlogForeignKey");

        modelBuilder.Entity<Plan>()
                .Property<int>("BlogForeignKey");

        modelBuilder.Entity<Plan>()
            .HasOne(p => p.Worker)
            .WithMany(b => b.Plans)
            .HasForeignKey("BlogForeignKey");
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Worker> Workers { get; set; }
    public virtual DbSet<Plan> Plans { get; set; }
    public virtual DbSet<Order> Orders { get; set; }

}
