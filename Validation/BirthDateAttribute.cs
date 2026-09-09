using System.ComponentModel.DataAnnotations;

namespace AjaxSergey.Validation;

public class BirthDateAttribute(int maxAge = 120) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime date) return ValidationResult.Success;
        
        var today = DateTime.Today;
        
        var minDate = today.AddYears(-maxAge);

        if (date > today) return new ValidationResult("Дата рождения не может быть в будущем.");
        
        return date < minDate ? new ValidationResult($"Дата рождения не может быть старше {maxAge} лет.") : ValidationResult.Success;
    }
}