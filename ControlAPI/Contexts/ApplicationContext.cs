using ControlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlAPI.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Group> Group { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
