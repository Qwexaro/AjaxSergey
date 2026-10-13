import { initApp } from "./AJAX.js";
// Гарантированный одиночный выпуск логики при готовности всего документа
if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", () => initApp());
}
else {
    initApp();
}
//# sourceMappingURL=site.js.map