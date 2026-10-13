import { initApp } from "./AJAX.js";
if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", () => initApp());
}
else {
    initApp();
}
//# sourceMappingURL=site.js.map