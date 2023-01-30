using Microsoft.EntityFrameworkCore;
using Tutorit.Models;

namespace Tutorit.Persistance;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<User> Users { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<UserSubject> UserSubjects { get; set; }

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("TutoritDb"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<Teacher>().ToTable("Teachers");
        modelBuilder.Entity<Student>().ToTable("Students");
    }

}