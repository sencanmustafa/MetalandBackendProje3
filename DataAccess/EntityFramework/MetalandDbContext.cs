using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework;

public class MetalandDbContext : DbContext
{
    public DbSet<Game> Game { get; set; }
    public DbSet<Management> Management { get; set; }
    public DbSet<ManagementDetails> ManagementDetails { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Area> Area { get; set; }
    public DbSet<Food> Food { get; set; }
    public DbSet<Money> Money { get; set; }
    public DbSet<Stuff> Stuff { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string constr = "Server=sql.athena.domainhizmetleri.com; Database=mustaf11_proje3; TrustServerCertificate=True; Integrated Security = False; User=mustaf11_sencan;Password=Mustiler463!";
            base.OnConfiguring(optionsBuilder.UseSqlServer(constr));
            Console.WriteLine("Connected");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        
        modelBuilder.Entity<Users>()
            .HasKey(u => u.UserId);
        
        modelBuilder.Entity<ManagementDetails>()
            .HasOne(md => md.Management)
            .WithMany(m => m.ManagementDetails)
            .HasForeignKey(md => md.ManagementId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Area>()
            .HasOne(a => a.OwnerUser)
            .WithMany(u => u.Areas)
            .HasForeignKey(a => a.AreaOwnerUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Area>()
            .HasOne(a => a.Management)
            .WithMany()
            .HasForeignKey(a => a.AreaType)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Food>()
            .HasOne(f => f.User)
            .WithMany(u => u.Foods)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Money>()
            .HasOne(m => m.User)
            .WithMany(u => u.Money)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Stuff>()
            .HasOne(s => s.User)
            .WithMany(u => u.Stuff)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
    
}