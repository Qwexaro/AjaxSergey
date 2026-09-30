namespace AjaxSergey.Models;

public record Student(
    int Id,
    string Name,
    string Phone,
    string Email,
    string Speciality,
    string LessonFormat,
    string? Message,
    string City,
    string Course,
    DateTime DateBirTime,
    List<string> Tech
);