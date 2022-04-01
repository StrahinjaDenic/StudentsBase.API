using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class ProfessorInputViewModel : IValidatableObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<int> CourseIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required!", new[] { nameof(Name) });
            }
            if (string.IsNullOrWhiteSpace(Surname))
            {
                yield return new ValidationResult("Surname is required!", new[] { nameof(Surname) });
            }
        }
    }
}
