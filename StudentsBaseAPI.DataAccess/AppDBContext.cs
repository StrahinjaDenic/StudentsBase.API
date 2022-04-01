using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentsBaseAPI.Common.Models;

namespace StudentsBaseAPI.DataAccess
{
    public class AppDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExaminationDate> ExaminationDates { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ProfessorCourse> ProfessorCourses { get; set; }
        public virtual DbSet<StudentPorfessorCourse> StudentPorfessorCourses { get; set; }

        public AppDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDBContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StudentsBaseDb"));
            }
        }
    }
}
