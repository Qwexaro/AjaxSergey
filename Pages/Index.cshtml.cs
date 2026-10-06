using System.ComponentModel.DataAnnotations;
using AjaxSergey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

    public static List<Student> Students { get; set; } = [];

    public static int NextId { get; set; } = 1;

    public void OnGet() { }

    public IActionResult OnPost() =>
        HelperPartial(
            "_StudentCard",
            new Student(
                NextId++,
                Name,
                Phone,
                Email,
                Speciality,
                LessonFormat,
                Message ?? "",
                City,
                Course,
                DateBirTime,
                Tech
            )
        );

    public IActionResult OnGetStudents() => HelperPartial("_StudentsList", Students);

    public IActionResult OnDeleteStudent(int id)
    {
        Students.RemoveAll(student => student.Id == id);

        return new OkResult();
    }

    private PartialViewResult HelperPartial(string viewName, object model) =>
        new()
        {
            ViewName = viewName,

            ViewData = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary()
            )
            {
                Model = model,
            },
        };
}
