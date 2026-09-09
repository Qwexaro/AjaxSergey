using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    
    public required string Message { get; set; }
    
    public void OnGet() {  }

    public void OnPost() => Message = $"Анкета студента\nName:{Name},\nPhone:{Phone},\nEmail:{Email},\nSpeciality:{Speciality}";
}
