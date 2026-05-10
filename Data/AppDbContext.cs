using EfCoreRelationshipDemo.Models.ManyToMany;
using EfCoreRelationshipDemo.Models.OneToMany;
using EfCoreRelationshipDemo.Models.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace EfCoreRelationshipDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Passport> Passports => Set<Passport>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne<Passport>(p => p.Passport)
            .WithOne(pp => pp.Person)
            .HasForeignKey<Passport>(pp => pp.PersonId);

        modelBuilder.Entity<Blog>()
            .HasMany<Post>(b => b.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId);

        modelBuilder.Entity<Post>()
            .HasOne<Blog>(p => p.Blog);

        modelBuilder.Entity<Enrollment>()
             .HasKey(e => new { e.StudentId, e.CourseId });

        modelBuilder.Entity<Enrollment>()
            .HasOne<Student>(p => p.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne<Course>(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);
    }
}
