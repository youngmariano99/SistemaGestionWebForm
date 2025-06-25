

//FUNCIÓN PARA ABRIR EL MODAL
function abrirModal(panelID) {
        console.log("Intentando abrir el modal...");

    var modal = document.querySelector("[id$='" + panelID + "']");

    if (modal) {
        modal.style.display = "block";
    } else {
        console.log("El modal no se encontró: " + panelID);

    }
}

//FUNCIÓN PARA CERRAR EL MODAL
function cerrarModal(panelID) {
    document.getElementById(panelID).style.display = "none";
 }

