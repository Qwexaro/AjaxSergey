using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AjaxSergey.Models;

namespace AjaxSergey.Pages;

public class IndexModel : PageModel
{
    [BindProperty] public required string Name { get; set; }

    [BindProperty] public required string Phone { get; set; }

    [BindProperty] public required string Email { get; set; }

    [BindProperty] public required string Speciality { get; set; }

    [BindProperty] public required string LessonFormat { get; set; }

    [BindProperty] public string? Message { get; set; }

    [BindProperty] public required string City { get; set; }

    [BindProperty] public required string Course { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Пожалуйста, укажите дату рождения")]
    public required DateTime DateBirTime { get; set; }

    [BindProperty] public required List<string> Tech { get; set; }

    public static List<Student> Students { get; set; } = [];

    public void OnGet() {  }

    public IActionResult OnPost() => new JsonResult(new Student
    (
        Id = ++Id,
        Name = Name, 
        Phone = Phone, 
        Email = Email, 
        Speciality = Speciality, 
        LessonFormat = LessonFormat, 
        Message = Message, 
        City = City, 
        Course = Course, 
        DateBirTime = DateBirTime, 
        Tech = Tech
    ));

    public int Id { get; set; }

    public IActionResult OnGetStudents() => new JsonResult(Students);
    
    public IActionResult OnDeleteStudent(int id) => new JsonResult(Students = [.. Students.Where(student => student.Id != id)]);
}