import { getForm } from "./Form.js";

export const getButton: () => HTMLButtonElement | null = (): HTMLButtonElement | null => {

    const form: HTMLFormElement | null = getForm();
    
    return form ? form.querySelector<HTMLButtonElement>('.form-button') : null;

};
