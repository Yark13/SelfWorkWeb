using Microsoft.EntityFrameworkCore;
using WebUniversity.DataLayer.Entity;

namespace WebUniversity.DataLayer
{
    public class StateDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public virtual DbSet<Course> Courses { get; set; } = default!;
        public virtual DbSet<Group> Groups { get; set; } = default!;
        public virtual DbSet<Student> Students { get; set; } = default!;

        public StateDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public StateDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            options
                .UseSqlServer(Configuration.GetConnectionString("MyDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new FillerDBData().Courses);
            modelBuilder.Entity<Group>().HasData(new FillerDBData().Groups);
            modelBuilder.Entity<Student>().HasData(new FillerDBData().Students);

            modelBuilder.Entity<Group>().HasOne(g => g.Course).WithMany(c => c.Groups).HasForeignKey(g => g.CourseID);

            modelBuilder.Entity<Student>().HasOne(s => s.Group).WithMany(g => g.Students).HasForeignKey(s => s.GroupId);
        }
    }
}