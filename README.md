<img width="1919" height="1029" alt="image" src="https://github.com/user-attachments/assets/5c69e3cd-68cf-4e87-8277-9195f9fa48ea" />

```AJAX.js
const form = document.querySelector('form');
const button = form.querySelector('.form-button');

let isSubmitting = false;

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    if (isSubmitting) return;

    isSubmitting = true;

    button.disabled = true;

    setTimeout(() => {
        console.info("sending data. . .");
    }, 2300);
    
    button.textContent = "Sending...";

    try {
        const formData = new FormData(form);
        const tokenElement = form.querySelector('input[name="__RequestVerificationToken"]');

        const response = await fetch("", {
            method: 'POST',
            headers: { "RequestVerificationToken": tokenElement?.value || "" },
            body: formData
        });

        document.querySelector('#result').textContent = await response.text();
    } catch (error) {
        console.error("Ошибка при отправке:", error);
    } finally {
        isSubmitting = false;
        button.disabled = false;
        button.textContent = "Send";
    }
});

```

```index.cshtml.cs
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
```

```index.cshtml
@page
@model IndexModel

<div class="form-container">
    <h1>Анкета студентов</h1>
    <form method="post">
        @Html.AntiForgeryToken()
        
        <div class="form-group">
            <label for="student-name">Имя фамилия:</label>
            <input type="text" name="Name" id="student-name" placeholder="Введите имя" autocomplete="name"/>
        </div>
        
        <div class="form-group">
            <label for="student-phone">Номер телефона:</label>
            <input type="tel" name="Phone" id="student-phone" placeholder="+7" required="required" autocomplete="tel"/>
        </div>
        
        <div class="form-group">
            <label for="student-email">Email:</label>
            <input type="email" name="Email" id="student-email" placeholder="email" autocomplete="email"/>
        </div>
        
        <div class="form-group">
            <label>Специальность:</label>
            <div class="speciality">
                <input type="radio" name="Speciality" value="Программирование" id="dev"/>
                <label for="dev">Программирование</label>
                <br>
                <input type="radio" name="Speciality" value="Дизайнер" id="design"/>
                <label for="design">Дизайн</label>
                <br>
                <input type="radio" name="Speciality" value="Маркетолог" id="marketing"/>
                <label for="marketing">Маркетинг</label>
            </div>
            
            <div>
                <label for="courses">Курс: </label>
                <select name="Course" id="courses">
                    <option value="1 курс">1 курс</option>
                    <option value="2 курс">2 курс</option>
                    <option value="3 курс">3 курс</option>
                    <option value="4 курс">4 курс</option>
                </select>
            </div>
            
            <div>
                <label for="birth-date">Дата рождения:</label>
                <input type="date" name="DateBirTime" id="birth-date" required autocomplete="bday"/>
            </div>
            
            <div class="form-group">
                <label>Технологии:</label>
                <div class="speciality">
                    <input type="checkbox" name="Tech" value="HTML/CSS" id="html"/>
                    <label for="html">HTML/CSS</label>
                    <br>
                    <input type="checkbox" name="Tech" value="JS" id="js"/>
                    <label for="js">JS</label>
                    <br>
                    <input type="checkbox" name="Tech" value="CS" id="cs"/>
                    <label for="cs">C#</label>
                    <br>
                    <input type="checkbox" name="Tech" value="Python" id="py"/>
                    <label for="py">Python</label>
                </div>
            </div>
            
            <div class="form-group">
                <label>Формат обучения</label>
                <div class="lessonformat">
                    <select name="LessonFormat" id="lesson-format">
                        <option value="Очно">Очно</option>
                        <option value="Удаленно">Удаленно</option>
                        <option value="Заочно">Заочно</option>
                    </select>
                </div>
            </div>
            
            <div class="form-group">
                <label>Город обучения обучения</label>
                <div class="city">
                    <select name="City" id="city">
                        <option value="Сочи">Сочи</option>
                        <option value="Москва">Москва</option>
                        <option value="Санкт-Питербург">Санкт-Питербург</option>
                        <option value="Казань">Казань</option>
                    </select>
                </div>
            </div>
            
        </div>
        
        <div class="form-group">
            <label for="student-message">Сообщение:</label>
            <textarea name="Message" id="student-message" placeholder="Дополнительная информация" autocomplete="off"></textarea>
        </div>

        <button class="form-button" type="submit">Send</button>
    </form>
    
    <div id="result" class="result"></div>
    
    @if (Model.Message is not null)
    {
        <div class="result">
            <h3>Данные анкеты</h3>
            <p style="white-space: pre-line">@Model.Message</p>
        </div>
    }
    
    <script src="/js/AJAX.js"></script>
</div>

```


``
