import { initApp } from "./AJAX.js";

if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", (): void => initApp());
} else {
    initApp();
}
