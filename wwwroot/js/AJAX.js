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
    }, 1300);
    
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
