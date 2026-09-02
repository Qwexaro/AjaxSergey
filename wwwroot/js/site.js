// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const sentData = async () => {
    const name = document.getElementById("name").value;

    const age = document.getElementById("age").value;

    const city = document.getElementById("city").value;

    const professional = document.getElementById("professional").value;

    const resultElement = document.getElementById("result");

    try {
        const response = await fetch(
            `?handler=Hello&name=${encodeURIComponent(name)}
            &age=${encodeURIComponent(age)}
            &city=${encodeURIComponent(city)}
            &professional=${encodeURIComponent(professional)}`
        );

        if (!response.ok) {
            throw new Error("Ошибка сети");
        }

        const data = await response.json();

        resultElement.textContent = data.message; 
    } catch (error) {
        console.error("Ошибка:", error);

        resultElement.textContent = "Произошла ошибка при запросе.";
    }
}