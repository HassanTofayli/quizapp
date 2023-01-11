namespace quizapp.Data;
using Microsoft.EntityFrameworkCore;
using quizapp.Models;
using System.Reflection;


public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<ClassRoom> ClassRooms { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}