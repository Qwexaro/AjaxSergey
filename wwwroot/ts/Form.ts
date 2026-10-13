export const getForm: () => HTMLFormElement | null = (): HTMLFormElement | null => {
    
    return document.querySelector<HTMLFormElement>('form');

};
