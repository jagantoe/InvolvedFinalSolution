using Contracts.DTOs;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration;

public class TodoDbContext : DbContext
{
    public DbSet<Todo> Todos {get; set;}
    
    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(library =>
        {
            library.HasKey(l => l.Id);

            library.Property(l => l.Title).IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }
}