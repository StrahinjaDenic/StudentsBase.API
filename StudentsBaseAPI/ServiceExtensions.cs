using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsBaseAPI.BusinessLogic;
using StudentsBaseAPI.DataAccess;
using StudentsBaseAPI.IBusinessLogic;
using StudentsBaseAPI.IDataAccess;

namespace StudentsBaseAPI
{
    public static class ServiceExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StudentsBaseDb"));
            });
            services.AddScoped<DbContext, AppDBContext>();
        }

        public static void MapInterfaceImplementation(this IServiceCollection services)
        {
            // add BL classes here
            services.AddTransient<ICourseBL, CourseBL>();
            services.AddTransient<IExamBL, ExamBL>();
            services.AddTransient<IExaminationDateBL, ExaminationDateBL>();
            services.AddTransient<IProfessorCourseBL, ProfessorCourseBL>();
            services.AddTransient<IProfessorBL, ProfessorBL>();
            services.AddTransient<IStudentBL, StudentBL>();
            services.AddTransient<IStudentProfessorCourseBL, StudentProfessorCourseBL>();

            // add DAL classes here
            services.AddTransient<ICourseDAL, CourseDAL>();
            services.AddTransient<IExamDAL, ExamDAL>();
            services.AddTransient<IExaminationDateDAL, ExaminationDateDAL>();
            services.AddTransient<IProfessorCourseDAL, ProfessorCourseDAL>();
            services.AddTransient<IProfessorDAL, ProfessorDAL>();
            services.AddTransient<IStudentDAL, StudentDAL>();
            services.AddTransient<IStudentProfessorCourseDAL, StudentProfessorCourseDAL>();

            services.AddHttpClient();
        }
    }
}
