import {status} from "./Status";
import {form} from "./Form";
import {button} from "./Button";
import {studentsList} from "./StudentsList";

let isSubmitting: boolean = false;

if (form) {

  form.addEventListener('submit', async (event: SubmitEvent): Promise<void> => {

    event.preventDefault();

    if (isSubmitting) return;

    isSubmitting = true;

    if (button) {

      button.disabled = true;

      button.textContent = "Sending...";

    }

    try {

      let formData: FormData = new FormData(form);

      const tokenElement: HTMLInputElement = form.querySelector<HTMLInputElement>('input[name="__RequestVerificationToken"]')!;

      const response = await fetch("", {

        method: 'POST',

        headers: { "RequestVerificationToken": tokenElement?.value || "" },

        body: formData

      });

      if (response.ok) {

        const htmlCard = await response.text();

        if (studentsList) studentsList.insertAdjacentHTML('beforeend', htmlCard);

        form.reset();

        if (status) {

          status.textContent = "Анкета успешно отправлена!";

          status.style.color = "green";

        }

      } else {

        console.error("Сервер вернул ошибку:", response.status);

        if (status) {

          status.textContent = `Ошибка сервера при отправке (Код: ${response.status})`;

          status.style.color = "red";

        }
      }

    } catch (error) {

      console.error("Ошибка при отправке:", error);

      if (status) {

        status.textContent = "Не удалось отправить анкету!";

        status.style.color = "red";

      }

    } finally {

      isSubmitting = false;

      if (button) {

        button.disabled = false;

        button.textContent = "Send";

      }

    }
  });

  form.addEventListener('reset', () => { if (status) status.textContent = ''; });

}


const loadStudents = async () => {

  if (!studentsList) return;

  try {

    const response = await fetch("?handler=Students");

    if (!response.ok) throw Error("Ошибка подключения к студентам");

    studentsList.innerHTML = await response.text();

  } catch (error) {

    console.error("Ошибка загрузки студентов: ", error);

    studentsList.innerHTML = `<div class="result">Не удалось загрузить список студентов</div>`;

  }

};

export const deleteStudent: (id: number) => Promise<void> = async (id: number): Promise<void> => {

  if (!confirm("Вы уверены, что хотите удалить этого студента?")) return;

  try {

    const tokenElement: HTMLFormElement | null = document.querySelector('input[name="__RequestVerificationToken"]');

    const response: Response = await fetch(`?handler=DeleteStudent&id=${id}`, {

      method: 'POST',

      headers: { "RequestVerificationToken": tokenElement?.value || "" }

    });

    if (response.ok) {
      const cardToRemove: Element | null = document.querySelector(`#student-${id}`);

      if (cardToRemove) {

        cardToRemove.remove();

      }

    } else {

      alert("Не удалось удалить студента на сервере.");

    }

  } catch (error) {

    console.error("Ошибка при удалении студента:", error);

  }

};

loadStudents().catch(err => { console.error("Глобальный сбой при загрузке студентов:", err); });