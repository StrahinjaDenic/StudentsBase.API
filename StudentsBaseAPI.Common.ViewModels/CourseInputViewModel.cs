using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsBaseAPI.Common.ViewModels
{
    public class CourseInputViewModel : IValidatableObject
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? Points { get; set; }

        public List<int> ProfessorIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                yield return new ValidationResult("Code is required!", new[] { nameof(Code) });
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required!", new[] { nameof(Name) });
            }
            if (Points == null)
            {
                yield return new ValidationResult("Points is required!", new[] { nameof(Points) });
            }
            else if (Points <= 0)
            {
                yield return new ValidationResult("Points must be greater than 0!", new[] { nameof(Points) });
            }
        }
    }
}
