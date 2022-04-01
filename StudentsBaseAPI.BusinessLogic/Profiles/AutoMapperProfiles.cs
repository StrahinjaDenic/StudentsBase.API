using AutoMapper;
using StudentsBaseAPI.Common.Models;
using StudentsBaseAPI.Common.ViewModels;
using System;
using System.Linq;

namespace StudentsBaseAPI.BusinessLogic.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Course, CourseViewModel>()
                .ReverseMap();

            CreateMap<Course, CourseInputViewModel>()
                .ForMember(x => x.ProfessorIds, x => x.MapFrom(src => src.ProfessorCourses.Select(pc => pc.ProfessorId)));

            CreateMap<CourseInputViewModel, Course>()
                .ForMember(x => x.ProfessorCourses, x => x.MapFrom(src => src.ProfessorIds.Select(p => new ProfessorCourse { ProfessorId = p })));

            CreateMap<Exam, ExamInputViewModel>()
               .ReverseMap();

            CreateMap<Exam, ExamViewModel> ()
                .ForMember(x => x.Index, x => x.MapFrom(src => src.Student.Index))
                .ForMember(x => x.CourseName, x => x.MapFrom(src => src.Course.Name))
                .ForMember(x => x.Year, x => x.MapFrom(src => src.ExaminationDate.Year))
                .ForMember(x => x.Mark, x => x.MapFrom(src => src.ExaminationDate.Mark))
                .ReverseMap();

            CreateMap<ExaminationDate, ExaminationDateViewModel>()
               .ReverseMap();

            CreateMap<ExaminationDate, ExaminationDateInputViewModel>()
              .ReverseMap();

            CreateMap<Student, StudentInputViewModel>()
                .ForMember(x => x.CoAndPrIds, x => x.MapFrom(src => src.StudentProfessorCourses.Select(c => c.ProfessorCourseId)));

            CreateMap<StudentInputViewModel, Student>()
                .ForMember(x => x.StudentProfessorCourses, x => x.MapFrom(src => src.CoAndPrIds.Select(c => new StudentPorfessorCourse { ProfessorCourseId = c })));

            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.GradeAverage, x => x.MapFrom(src => src.Exams.Where(c => c.Grade > 5).Any() ? Math.Round(src.Exams.Where(c => c.Grade > 5)
                                                                                                    .GroupBy(c => c.CourseId)
                                                                                                    .Average(c => c.Max(i => i.Grade)), 2) : 0));
            CreateMap<ProfessorCourse, ProfessorCourseViewModel>()
                .ForMember(x => x.ProfessorCoursesNames, x => x.MapFrom(src => src.Professor.Name + " " + src.Professor.Surname + " - " + src.Course.Name));

            CreateMap<Professor, ProfessorViewModel>()
                .ForMember(x => x.CourseNames, x => x.MapFrom(src => src.ProfessorCourses.Select(t => t.Course.Name)));

            CreateMap<Professor, ProfessorInputViewModel>()
               .ForMember(x => x.CourseIds, x => x.MapFrom(src => src.ProfessorCourses.Select(c => c.CourseId)));

            CreateMap<ProfessorInputViewModel, Professor>()
                .ForMember(x => x.ProfessorCourses, x => x.MapFrom(src => src.CourseIds.Select(c => new ProfessorCourse { CourseId = c })));
        }
    }
}
