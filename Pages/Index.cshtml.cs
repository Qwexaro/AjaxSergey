using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AjaxSergey.Pages;

public class IndexModel : PageModel
{
    public JsonResult OnGetHello(string name, int age, string city, string professional) => new JsonResult(
        new {message = $"Hello, {name}! From {city}, with age: {age}, you a {professional}. Nice to meet you!"}
    );
}
