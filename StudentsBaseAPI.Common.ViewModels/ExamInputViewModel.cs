using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class ExamInputViewModel : IValidatableObject
    {
        public int? Id { get; set; }

        [Display(Name = "Index")]
        public int? StudentId { get; set; }

        [Display(Name = "Course name")]
        public int? CourseId { get; set; }

        [Display(Name = "Examination month/year")]
        public int? ExaminationDateId { get; set; }

        public short? Grade { get; set; }

        [Display(Name = "Exam date")]
        public DateTime? ExamDate { get; set; }

        public short? Points { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StudentId == null)
            {
                yield return new ValidationResult("Index is required!", new[] { nameof(StudentId) });
            }
            else if (StudentId <= 0)
            {
                yield return new ValidationResult("Index is invalid!", new[] { nameof(StudentId) });
            }
            if (CourseId == null)
            {
                yield return new ValidationResult("Course is required!", new[] { nameof(CourseId) });
            }
            else if (CourseId <= 0)
            {
                yield return new ValidationResult("Course is invalid!", new[] { nameof(CourseId) });
            }
            if (ExaminationDateId == null)
            {
                yield return new ValidationResult("Examination date is required!", new[] { nameof(ExaminationDateId) });
            }
            else if (ExaminationDateId <= 0)
            {
                yield return new ValidationResult("Examination date is invalid!", new[] { nameof(ExaminationDateId) });
            }
            if (Grade == null)
            {
                yield return new ValidationResult("Grade is required!", new[] { nameof(Grade) });
            }
            else if (Grade <= 0)
            {
                yield return new ValidationResult("Grade is invalid!", new[] { nameof(Grade) });
            }
            if (Points < 0 || Points > 100)
            {
                yield return new ValidationResult("Points must be between 0 and 100!", new[] { nameof(Points) });
            }
        }
    }
}
