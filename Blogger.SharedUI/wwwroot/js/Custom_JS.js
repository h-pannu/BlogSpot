window.Alert = function (message) {
    alert(message);
};
window.openModal = (id) => document.getElementById(id).showModal();
window.closeModal = (id) => document.getElementById(id).close();