using DL.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DL.Settings;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<UserSession> UserSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserSession>().HasKey(ut => ut.ID);
    }
}
