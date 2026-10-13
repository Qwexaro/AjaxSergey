import { getForm } from "./Form.js";
export const getButton = () => {
    const form = getForm();
    return form ? form.querySelector('.form-button') : null;
};
//# sourceMappingURL=Button.js.map