using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AjaxSergey.Extensions;
using AjaxSergey.Validation;
using System.Text.Json;

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
    public required DateTime DateBirTime { get; set; }

    [BindProperty] 
    public required List<string> Tech { get; set; }
    
    public void OnGet() {  }
    
    public IActionResult OnPost() => Content(JsonSerializer.Serialize(new 
    { 
        Name, 
        Phone, 
        Email, 
        Speciality, 
        LessonFormat, 
        Message, 
        City, 
        Course, 
        DateBirTime, 
        Tech 
    }), "application/json");
}