using Domain.DTOs;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Address> Addresss { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>().HasKey(stg => new { stg.StudentId, stg.GroupId });
    }

}
    