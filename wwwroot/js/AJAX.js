const form = document.querySelector('form');

form.addEventListener('submit', async (event) => {
    event.preventDefault();

    const formData = new FormData(form);
    
    const tokenElement = form.querySelector('input[name="__RequestVerificationToken"]');
    if (!tokenElement) {
        console.error("Критическая ошибка: Токен защиты не найден на форме!");
        return;
    }
    
    const response = await fetch("", {
        method: 'POST',
        headers: {
            "RequestVerificationToken": tokenElement.value
        },
        body: formData
    });

    const resultDiv = document.querySelector('#result');
    
    // for imitation server work
    await new Promise(resolve => setTimeout(resolve, 1300));
    
    resultDiv.textContent = await response.text();
});

