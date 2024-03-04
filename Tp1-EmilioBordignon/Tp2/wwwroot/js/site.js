// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function obtenerHora() {
    const ahora = new Date();
    const horas = ahora.getHours();
    const minutos = ahora.getMinutes();
    const segundos = ahora.getSeconds();

    const horaActual = `${horas}:${minutos}:${segundos}`;

    // Actualiza el contenido del botón con la hora actual
    document.getElementById("botonHora").innerHTML = horaActual;
}

// Agrega un evento click al botón para llamar a la función obtenerHora
document.getElementById("botonHora").addEventListener("click", obtenerHora);

function modal() {
    const modalAsistencias = new bootstrap.Modal(document.getElementById("detalle"));

    modalAsistencias.show()
}