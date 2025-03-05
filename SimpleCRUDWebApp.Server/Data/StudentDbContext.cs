using Microsoft.EntityFrameworkCore;
using SimpleCRUDWebApp.Server.Entities;

namespace SimpleCRUDWebApp.Server.Data
{
    public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options)
    {
        internal object students;

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }
    }
}
