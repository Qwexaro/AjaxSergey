<img width="1916" height="1051" alt="image" src="https://github.com/user-attachments/assets/74bea921-8b5c-4439-b58a-45b157b3dd47" />


```csharp
namespace AjaxSergey.Models;

public record Student(
    int Id,
    string Name,
    string Phone,
    string Email,
    string Speciality,
    string LessonFormat,
    string Message,
    string City,
    string Course,
    DateTime DateBirTime,
    List<string> Tech
);
```
