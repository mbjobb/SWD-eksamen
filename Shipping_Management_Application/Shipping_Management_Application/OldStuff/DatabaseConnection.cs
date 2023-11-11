/**using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class DatabaseConnection : DbContext
{

   // public DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("FileName=sqlitedb1", options =>
        {
            options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().ToTable("admins", "test");
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(k => k.AdminId);
            entity.HasIndex(i => i.UserName).IsUnique();

        });
        base.OnModelCreating(modelBuilder);
    }
}
**/