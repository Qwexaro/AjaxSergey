using Microsoft.AspNetCore.Mvc;
using AjaxSergey.Models.Entities;

namespace AjaxSergey.Controllers;

public class CreateResumeController : Controller
{
    static readonly List<Student> Students = [];

    [HttpGet]
    public IActionResult GetStudents() => PartialView("_StudentsList", Students);

    [HttpPost]
    public IActionResult Submit(Student student)
    {
        if (!ModelState.IsValid) return BadRequest("Данные анкеты не прошли валидацию.");

        var newStudent = student with { Id = Students.Count + 1 };

        Students.Add(newStudent);

        return PartialView("_StudentCard", newStudent);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var student = Students.Find(s => s.Id == id);

        if (student == null) return NotFound();

        Students.Remove(student);

        return Ok();
    }
}