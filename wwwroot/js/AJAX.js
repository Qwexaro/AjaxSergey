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

            headers: {"RequestVerificationToken": tokenElement?.value || ""},

            body: formData

        });

        if (response.ok) {

            const rawText = await response.text();

            const jsonObject = JSON.parse(rawText);

            const formattedJson = JSON.stringify(jsonObject, null, 4);

            const resultBlock = document.querySelector('#result');

            const jsonOutput = document.querySelector('#jsonOutput');

            if (jsonOutput && resultBlock) {

                jsonOutput.textContent = formattedJson;

                resultBlock.style.display = 'block';

            }

        } else {

            console.error("Сервер вернул ошибку:", response.status);

        }

    } catch (error) {

        console.error("Ошибка при отправке:", error);

    } finally {

        isSubmitting = false;

        button.disabled = false;

        button.textContent = "Send";

    }
});
