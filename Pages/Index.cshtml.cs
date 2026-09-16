using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AjaxSergey.Extensions;
using AjaxSergey.Validation;

namespace AjaxSergey.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public required string Name { get; set; }
    
    [BindProperty]
    public required string Phone { get; set; }
    
    [BindProperty]
    public required string Email { get; set; }
    
    [BindProperty]
    public required string Speciality { get; set; }
    
    [BindProperty]
    public required string LessonFormat { get; set; }
    
    [BindProperty]
    public string? Message { get; set; }
    
    [BindProperty]
    public required string City { get; set; }
    
    [BindProperty]
    public required string Course { get; set; }
    
    [BindProperty]
    [Required(ErrorMessage = "Пожалуйста, укажите дату рождения")]
    [BirthDate(maxAge: 120)]
    [DataType(DataType.Date)]
    public required DateTime DateBirTime { get; set; }

    [BindProperty] 
    public required List<string> Tech { get; set; }
    
    public void OnGet() {  }
    
    public IActionResult OnPost() => 
        Content($"Анкета студента\nName:{Name},\nPhone:{Phone},\nEmail:{Email},\nSpeciality:{Speciality},\nCourse:{Course},\nDateBirTime:{DateBirTime},\nTech:{Tech.WriteList()}\nLessonFormat:{LessonFormat}\n,City:{City},\n\nMessage:{Message}");
}
